using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IPhoneNumberManager
    {
        IList<Phone> GetAll();
        Phone Get(int id);
        void Add(Phone phone);
        void Update(Phone phone);
        void Delete(int id);
    }
}
