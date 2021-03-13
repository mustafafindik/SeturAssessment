using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IEmailManager
    {
        IList<Email> GetAll();
        Email Get(int id);
        void Add(Email email);
        void Update(Email email);
        void Delete(int id);
    }
}
