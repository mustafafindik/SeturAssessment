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

        public IQueryable<ReportBody> GetReportBody()
        {
            var queryx = _context.Locations.Include(q => q.ContactLocations).ThenInclude(q => q.Contact)
                .ThenInclude(q => q.PhoneNumbers)
                .Select(q => new ReportBody()
                {
                    Location = q.LocationName,
                    ContactCount = q.ContactLocations.Select(q => q.Contact).Count(),
                    PhoneNumberCount = q.ContactLocations.Select(q => q.Contact).Sum(q => q.PhoneNumbers.Count)

                });

            var query4 = _context.ContactLocation.Include(q => q.Location).Include(q => q.Contact).ThenInclude(q => q.PhoneNumbers)
                .GroupBy(q => q.Location.LocationName)
                .Select(q => new ReportBody()
                {
                    Location = q.Key,
                    ContactCount = q.Select(Q => Q.Contact).Count(),
                    PhoneNumberCount = q.Select(Q => Q.Contact.PhoneNumbers).Count()

                });



            var query2 = (from location in _context.Locations
                          join contactlocation in _context.ContactLocation on location.Id equals contactlocation.LocationId
                          join contact in _context.Contacts.Include(q => q.PhoneNumbers) on contactlocation.ContactId equals
                              contact.Id
                          select new ReportBody()
                          {
                              Location = location.LocationName,
                              ContactCount = location.ContactLocations.Count,
                              // PhoneNumberCount = contact.PhoneNumbers.Count,

                          });

            var query1 = (from location in _context.Locations
                          join contactlocation in _context.ContactLocation on location.Id equals contactlocation.LocationId into cl
                          from defaultVal in cl.DefaultIfEmpty()
                          join contact in _context.Contacts.Include(q => q.PhoneNumbers) on defaultVal.ContactId equals contact.Id
                          select new ReportBody()
                          {
                              Location = location.LocationName,
                              ContactCount = location.ContactLocations.Count,
                              //PhoneNumberCount = contact.PhoneNumbers.Count,

                          });

        


            return queryx;
        }

        public async Task<IList<ReportBody>> GetReportBodyAsync()
        {
            IList<ReportBody> query = new List<ReportBody>();
            var locations = await _context.Locations.ToListAsync();
            foreach (var location in locations)
            {
                var phoneCount = 0;
                var locationContacts = await _context.ContactLocation.Where(q => q.LocationId == location.Id).Select(q => q.ContactId).ToListAsync();
                locationContacts.ForEach(async q =>
                {
                    phoneCount += await _context.PhoneNumbers.Where(c => c.ContactId == q).CountAsync();
                });


                var x = new ReportBody
                {
                    Location = location.LocationName,
                    ContactCount = locationContacts.Count,
                    PhoneNumberCount = phoneCount
                };
                query.Add(x);
            }


            return query;
        }
    }
}
