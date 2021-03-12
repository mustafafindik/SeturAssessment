using System;
using SeturTest.Contact.Entities.Abstract;

namespace SeturAssessment.Reports.Entities.Concrete
{
    public class Reports : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int StatusId { get; set; }
        public ReportStatus ReportStatus { get; set; }

    } 
}
