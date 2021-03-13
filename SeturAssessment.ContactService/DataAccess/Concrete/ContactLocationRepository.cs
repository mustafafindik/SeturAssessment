using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.DataAccess.Concrete
{
    public class ContactLocationRepository : EntityRepository<ContactLocation, ApplicationDbContext>, IContactLocationRepository
    {
        public ContactLocationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
