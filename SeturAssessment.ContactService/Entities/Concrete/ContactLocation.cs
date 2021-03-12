using System;

namespace SeturAssessment.ContactService.Entities.Concrete
{
    public class ContactLocation
    {
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
