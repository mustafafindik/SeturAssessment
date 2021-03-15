using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.DataAccess.Concrete
{
    public class ContactRepository: EntityRepository<Contact,Guid, ApplicationDbContext>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context) : base(context)
        {
        }

     
    }
}
