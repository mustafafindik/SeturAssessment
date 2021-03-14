using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ReportService.Entities.Concrete;
using SeturAssessment.ReportService.Utilities.Results;

namespace SeturAssessment.ReportService.Business.Abstract
{
    public interface IReportManager
    {
        IDataResult<IList<Report>> GetAll();
        IDataResult<Report> Get(Guid id);
        Task<IDataResult<Report>> AddAsync(Report report);
        Task<IDataResult<string>> GetReportBodyAsync();
        Task UpdateAsync(Report report);


    }
}
