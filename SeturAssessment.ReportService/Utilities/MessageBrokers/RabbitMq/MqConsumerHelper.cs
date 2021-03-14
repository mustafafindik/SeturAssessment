using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SeturAssessment.ContactService.Entities.ViewModels;
using SeturAssessment.ReportService.Business.Abstract;
using SeturAssessment.ReportService.DataAccess.Abstract;
using SeturAssessment.ReportService.Entities.Concrete;
using SeturAssessment.ReportService.Entities.Dto;
using SeturAssessment.ReportService.Entities.ViewModels;

namespace SeturAssessment.ReportService.Utilities.MessageBrokers.RabbitMq
{
    public class MqConsumerHelper : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private string _queueName;

        private readonly MessageBrokerOptions _brokerOptions;
        private readonly IReportManager _reportManager;

        public MqConsumerHelper(IConfiguration configuration, IReportManager reportManager)
        {
            _reportManager = reportManager;
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


                HandleMessage(message).Wait(stoppingToken);

            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;

        }


        private async Task HandleMessage(string message)
        {

            var result = JsonConvert.DeserializeObject<ResponseModel>(message);
            Report reportPending = new Report() { RequestDate = DateTime.Now, ReportStatusId = 1 };

            //CreateReport Reading
            await _reportManager.AddAsync(reportPending);
            //ReportBody
            var reportBody = await _reportManager.GetReportBodyAsync(result);


            //UpdateReportforReady
            var report = _reportManager.Get(reportPending.Id);
            report.Data.ReportBody = reportBody.Data;
            report.Data.ReportStatusId = 2;
            await _reportManager.UpdateAsync(report.Data);
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
