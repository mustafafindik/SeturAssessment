using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Entities.Dto
{
    public class ContactListDto:IDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }

        public ContactDetailDto[] ContactDetail { get; set; }
       
    }
}
