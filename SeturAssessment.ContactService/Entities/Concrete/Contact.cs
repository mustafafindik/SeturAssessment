using System;
using System.Collections.Generic;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Concrete
{
    public class Contact: IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }

        public virtual  ICollection<Email> Emails { get; set; }
    }
}
