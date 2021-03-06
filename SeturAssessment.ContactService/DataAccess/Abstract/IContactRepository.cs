using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.DataAccess.Abstract
{
    public interface IContactRepository : IEntityRepository<Contact,Guid>
    {
    }
}
