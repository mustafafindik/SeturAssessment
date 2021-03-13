using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ReportService.Business.Abstract;
using SeturAssessment.ReportService.DataAccess.Abstract;
using SeturAssessment.ReportService.Entities.Concrete;

namespace SeturAssessment.ReportService.Business.Concrete
{
    public class ReportManager:IReportManager
    {
        private readonly IReportRepository _reportRepository;

        public ReportManager(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IList<Report> GetAll()
        {
            return _reportRepository.GetAll().ToList();
        }

        public Report Get(Guid id)
        {
            return _reportRepository.Get(id);
        }

        public async Task<Report> AddAsync(Report report)
        {
            var result =  await _reportRepository.AddAsync(report);
            return result;
        }
    }
}
