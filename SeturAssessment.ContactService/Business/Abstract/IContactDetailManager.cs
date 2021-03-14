using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Abstract
{
    public interface IContactDetailManager
    {
        Task<IResult> AddAsync(ContactDetail contactDetail);
        Task<IResult> UpdateAsync(ContactDetail contactDetail);
        Task<IResult> DeleteAsync(Guid id);
    }
}
