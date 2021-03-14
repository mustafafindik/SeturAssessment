using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SeturAssessment.ReportService.Entities.Abstract;
using SeturAssessment.ReportService.Entities.Dto;

namespace SeturAssessment.ReportService.Entities.Concrete
{
    public class Report : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int ReportStatusId { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportBody { get; set; }

        public ReportBody[] GetnReportBodies()
        {
            return JsonConvert.DeserializeObject<List<ReportBody>>(ReportBody).ToArray();
        }

    } 
}
