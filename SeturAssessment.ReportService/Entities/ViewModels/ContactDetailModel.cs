using System;

namespace SeturAssessment.ReportService.Entities.ViewModels
{
    public class ContactDetailModel 
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
