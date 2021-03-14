using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ReportService.Entities.Concrete;

namespace SeturAssessment.ReportService.Entities.Dto
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public string StatusName { get; set; }
        public List<ReportBody> ReportBody { get; set; }
    }
}
