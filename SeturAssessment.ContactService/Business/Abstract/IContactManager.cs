using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IContactManager
    {
        IList<Contact> GetAll();
        Contact Get(Guid id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Guid id);
    }
}
