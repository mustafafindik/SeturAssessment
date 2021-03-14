using System;

namespace SeturAssessment.ContactService.Entities.ViewModels
{
    public class Report 
    {
        public Guid Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int ReportStatusId { get; set; }
        public string ReportBody { get; set; }

    } 
}
