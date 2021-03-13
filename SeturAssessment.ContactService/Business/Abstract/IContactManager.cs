using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IContactManager
    {
        IDataResult<IList<Contact>> GetAll();
        IDataResult<Contact> Get(Guid id);
        IResult Add(Contact contact);
        IResult Update(Contact contact);
        IResult Delete(Guid id);
    }
}
