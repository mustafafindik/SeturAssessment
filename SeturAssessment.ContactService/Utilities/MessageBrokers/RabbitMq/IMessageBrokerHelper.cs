namespace SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq
{
    public interface IMessageBrokerHelper
    {
        void QueueMessage(string messageText);
    }
}
