using SeturAssessment.ReportService.Entities.Abstract;

namespace SeturAssessment.ReportService.Entities.Concrete
{
    public class ReportStatus:IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
