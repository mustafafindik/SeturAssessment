using System;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Concrete
{
    public class ContactLocation:IEntity
    {
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
