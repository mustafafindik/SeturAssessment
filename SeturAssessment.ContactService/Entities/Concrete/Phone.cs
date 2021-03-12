using System;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Concrete
{
    public class Phone : IEntity
    {
        public int Id { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
        public string  PhoneNumber { get; set; }
    } 
}
