using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Utilities.Constants;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Concrete
{
    public class ContactDetailManager : IContactDetailManager
    {
        private readonly IContactDetailRepository _contactDetailRepository;

        public ContactDetailManager(IContactDetailRepository contactDetailRepository)
        {
            _contactDetailRepository = contactDetailRepository;
        }

        public async Task<IDataResult<IList<ContactDetail>>> GetContactDetailsAsync()
        {
            var query = await _contactDetailRepository.GetAllAsync();
            return new SuccessDataResult<List<ContactDetail>>(query.ToList(), Messages.ContactsDetailGet);
        }

        public async Task<IResult> AddAsync(ContactDetail contactDetail)
        {
            await _contactDetailRepository.AddAsync(contactDetail);
            return new SuccessResult(Messages.ContactDetailAdded);
        }

        public async Task<IResult> UpdateAsync(ContactDetail contactDetail)
        {
            await _contactDetailRepository.UpdateAsync(contactDetail,contactDetail.Id);
            return new SuccessResult(Messages.ContactDetailUpdated);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            await _contactDetailRepository.DeleteAsync(id);
            return new SuccessResult(Messages.ContactDetailDeleted);
        }
    }
}
