using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Dto
{
    public class EmailListDto:IDto
    {
        public int Id { get; set; }
        public string MailAddress { get; set; }
    }
}
