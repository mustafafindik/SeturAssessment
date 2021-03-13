using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.Dto;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface ILocationManager
    {
        IDataResult<IList<ContactLocation>> GetAll();
        IDataResult<ContactLocation> Get(Guid contactId);
        IResult Add(ContactLocationAddDto contactLocationAddDto);
        IResult Update(ContactLocationDto contactLocationDto);
        IResult Delete(ContactLocation contactLocation);
    }
}
