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
        Task<IDataResult<IList<Contact>>> GetAllAsync();
        Task<IDataResult<Contact>> GetAsync(Guid id);
        Task<IResult> AddAsync(Contact contact);
        Task<IResult> UpdateAsync(Contact contact);
        Task<IResult> DeleteAsync(Guid id);

    }
}
