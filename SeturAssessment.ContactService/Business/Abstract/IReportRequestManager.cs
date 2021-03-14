using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.ViewModels;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IReportRequestManager
    {
        Task<IDataResult<IList<ReportBody>>> GetAll();
        Task<IDataResult<Report>> SendReportRequestAsync();

    }
}
