using System;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Concrete
{
    public class Email : IEntity
    {
        public int Id { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
        public string MailAddress { get; set; }
    }
}
