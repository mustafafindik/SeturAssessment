using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ReportService.Entities.ViewModels;

namespace SeturAssessment.ContactService.Entities.ViewModels
{
    public class ResponseModel
    {
        public List<ContactDetailModel> ContactDetails { get; set; }
        public string location { get; set; }
    }
}
