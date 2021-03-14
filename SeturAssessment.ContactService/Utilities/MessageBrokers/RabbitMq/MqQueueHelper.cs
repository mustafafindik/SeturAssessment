using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SeturAssessment.ContactService.Entities.ViewModels;

namespace SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq
{
    public class MqQueueHelper : IMessageBrokerHelper
    {
        public readonly IConfiguration Configuration;
        private readonly MessageBrokerOptions _brokerOptions;
        public MqQueueHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _brokerOptions = Configuration.GetSection("MessageBrokerOptions").Get<MessageBrokerOptions>();
        }

        public void QueueMessage(IRequestModel model)
        {
            var QueueName = _brokerOptions.QueueName;
            var factory = new ConnectionFactory
            {
                
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password,
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                        queue: QueueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                var message = JsonConvert.SerializeObject(model);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
            }
        }
    }
}
