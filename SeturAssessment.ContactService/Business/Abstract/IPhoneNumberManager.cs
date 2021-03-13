using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IPhoneNumberManager
    {
        IDataResult<IList<Phone>> GetAll();
        IDataResult<Phone> Get(int id);
        IResult Add(Phone phone);
        IResult Update(Phone phone);
        IResult Delete(int id);
    }
}
