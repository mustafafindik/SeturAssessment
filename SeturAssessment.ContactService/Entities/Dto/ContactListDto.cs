using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Dto
{
    public class ContactListDto:IDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }

        public EmailListDto[] Emails { get; set; }
        public PhoneListDto[] PhoneNumbers { get; set; }
        public ContactLocationDto[] Locations { get; set; }
    }
}
