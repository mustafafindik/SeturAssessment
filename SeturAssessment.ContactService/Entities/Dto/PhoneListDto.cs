using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Dto
{
    public class PhoneListDto:IDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
    }
}
