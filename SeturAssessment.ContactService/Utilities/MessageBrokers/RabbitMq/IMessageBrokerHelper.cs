using SeturAssessment.ContactService.Entities.ViewModels;

namespace SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq
{
    public interface IMessageBrokerHelper
    {
        void QueueMessage(IRequestModel model);
    }
}
