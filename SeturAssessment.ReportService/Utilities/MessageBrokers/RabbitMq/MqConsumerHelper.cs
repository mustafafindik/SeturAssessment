using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SeturAssessment.ReportService.DataAccess.Abstract;

namespace SeturAssessment.ReportService.Utilities.MessageBrokers.RabbitMq
{
    public class MqConsumerHelper : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private string _queueName;

        private readonly MessageBrokerOptions _brokerOptions;
        private readonly IReportRepository _reportRepository;

        public MqConsumerHelper(IConfiguration configuration, IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
            _brokerOptions = configuration.GetSection("MessageBrokerOptions").Get<MessageBrokerOptions>();
            InitializeRabbitMqListener();
        }

        private void InitializeRabbitMqListener()
        {
              _queueName = _brokerOptions.QueueName;

            var factory = new ConnectionFactory()
            {
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, mq) =>
            {

                var body = mq.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                HandleMessage(message);

            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;

        }


        private void HandleMessage(string message)
        {
            var repo = _reportRepository.GetAll().Where(q => q.ReportBody == null).FirstOrDefault();
            repo.ReportBody = message;
            _reportRepository.UpdateAsync(repo);
        }

        public virtual void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

    }
}
