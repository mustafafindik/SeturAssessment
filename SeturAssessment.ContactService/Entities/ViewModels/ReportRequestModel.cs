using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Entities.ViewModels
{
    public class ReportRequestModel: IRequestModel
    {
        public List<Contact> Contacts { get; set; }
    }
}
