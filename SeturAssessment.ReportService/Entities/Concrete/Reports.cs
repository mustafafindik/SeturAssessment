using System;
using SeturAssessment.ReportService.Entities.Abstract;

namespace SeturAssessment.ReportService.Entities.Concrete
{
    public class Reports : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int ReportStatusId { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportBody { get; set; }

    } 
}
