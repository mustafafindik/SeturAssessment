using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Concrete
{
    public class ContactManager : IContactManager
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }



        public async Task<IDataResult<IList<Contact>>> GetAllAsync()
        {
            var query = await _contactRepository.GetAllAsync("ContactDetails");
            return new SuccessDataResult<List<Contact>>(query.ToList(), "Kişiler Başarıyla Alındı");
        }

        public async Task<IDataResult<Contact>> GetAsync(Guid id)
        {
            var query = await _contactRepository.GetAsync(q => q.Id == id, "ContactDetails");
            return new SuccessDataResult<Contact>(query, "Kişi Başarıyla Alındı");
        }

        public  async Task<IResult> AddAsync(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
            return new SuccessResult("Kişi Başarıyla Kaydedildi.");
        }

        public async Task<IResult> UpdateAsync(Contact contact)
        {
            await _contactRepository.UpdateAsync(contact, contact.Id);
            return new SuccessResult("Kişi Başarıyla Güncellendi.");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            await _contactRepository.DeleteAsync(id);
            return new SuccessResult("Kişi Başarıyla Silindi.");
        }
    }
}
