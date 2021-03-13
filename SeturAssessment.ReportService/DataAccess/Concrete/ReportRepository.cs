using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ReportService.DataAccess.Abstract;
using SeturAssessment.ReportService.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SeturAssessment.ReportService.Entities.Concrete;

namespace SeturAssessment.ReportService.DataAccess.Concrete
{
    public class ReportRepository:IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Report> GetAll()
        {
            return _context.Reports;
        }

        public Report Get(Guid id)
        {
            return _context.Reports.FirstOrDefault(q=>q.Id==id);
        }

        public async Task<Report> AddAsync(Report report)
        {
            await _context.AddAsync(report);
            await _context.SaveChangesAsync();

            return report;
        }

        public async Task UpdateAsync(Report report)
        {
            var existingEntity = await _context.Reports.FindAsync(report.Id);
             _context.Entry(existingEntity).CurrentValues.SetValues(report);
            await _context.SaveChangesAsync();
        }
    }
}
