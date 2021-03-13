using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ReportService.Entities.Concrete;

namespace SeturAssessment.ReportService.Business.Abstract
{
    public interface IReportManager
    {
        IList<Report> GetAll();
        Report Get(Guid id);
        Task<Report> AddAsync(Report report);
    }
}
