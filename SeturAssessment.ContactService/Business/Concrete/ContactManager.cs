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

        public IDataResult<IList<Contact>> GetAll()
        {
            var query = _contactRepository.GetAll(new string[] { "Emails", "PhoneNumbers", "ContactLocations.Location" }).ToList();
            return new SuccessDataResult<List<Contact>>(query, "Kişiler Başarıyla Alındı");

        }

        public IDataResult<Contact> Get(Guid id)
        {
            var query = _contactRepository.GetAll(new string[] { "Emails", "PhoneNumbers", "ContactLocations.Location" }).FirstOrDefault(q=>q.Id==id);
            return new SuccessDataResult<Contact>(query, "Kişi Başarıyla Alındı");

        }

        public IResult Add(Contact contact)
        {
            _contactRepository.Add(contact);
            return new SuccessResult("Kişi Başarıyla Kaydedildi.");
        }

        public IResult Update(Contact contact)
        {
            _contactRepository.Update(contact,contact.Id);
            return new SuccessResult("Kişi Başarıyla Güncellendi.");

        }

        public IResult Delete(Guid id)
        {
            var entity = _contactRepository.Get(q => q.Id == id);
            _contactRepository.Delete(entity,entity.Id);
            return new SuccessResult("Kişi Başarıyla Silindi.");

        }
    }
}
