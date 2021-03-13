using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IEmailManager
    {
        IDataResult<IList<Email>> GetAll();
        IDataResult<Email> Get(int id);
        IResult Add(Email email);
        IResult Update(Email email);
        IResult Delete(int id);
    }
}
