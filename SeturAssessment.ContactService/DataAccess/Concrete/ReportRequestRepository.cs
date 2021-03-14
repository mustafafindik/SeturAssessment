using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SeturAssessment.ContactService.Entities.ViewModels;

namespace SeturAssessment.ContactService.DataAccess.Concrete
{
    public class ReportRequestRepository:IReportRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IList<ReportBody>> GetReportBodyAsync()
        {
            IList<ReportBody> query = new List<ReportBody>();
            var locations = await _context.ContactDetails.Select(q=>q.Location).Distinct().ToListAsync();
            foreach (var location in locations)
            {
               
                var x = new ReportBody
                {
                    Location = location,
                    ContactCount = await _context.ContactDetails.Where(q => q.Location == location).Select(q => q.ContactId).CountAsync(),
                    PhoneNumberCount = await _context.ContactDetails.Where(q => q.Location == location).Select(q => q.Phone).CountAsync(),
                };
                query.Add(x);
            }


            return query;
        }
    }
}
