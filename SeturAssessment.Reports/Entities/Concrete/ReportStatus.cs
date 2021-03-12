using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturTest.Contact.Entities.Abstract;

namespace SeturAssessment.Reports.Entities.Concrete
{
    public class ReportStatus:IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
