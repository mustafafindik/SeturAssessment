using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturAssessment.ContactService.Entities.ViewModels
{
    public class ReportBody
    {
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }

    }
}
