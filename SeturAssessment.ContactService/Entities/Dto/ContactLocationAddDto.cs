using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Dto
{
    public class ContactLocationAddDto:IDto
    {
        public Guid ContactId { get; set; }
        public string LocationName { get; set; }
    }
}
