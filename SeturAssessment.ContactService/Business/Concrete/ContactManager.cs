using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Business.Concrete
{
    public class ContactManager : IContactManager
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IList<Contact> GetAll()
        {
           return _contactRepository.GetAll(new string[] {"Emails", "PhoneNumbers", "ContactLocations.Location"}).ToList();
        }

        public Contact Get(Guid id)
        {
            return _contactRepository.GetAll(new string[] { "Emails", "PhoneNumbers", "ContactLocations.Location" }).FirstOrDefault(q=>q.Id==id);

        }

        public void Add(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }

        public void Delete(Guid id)
        {
            var entity = _contactRepository.Get(q => q.Id == id);
            _contactRepository.Delete(entity);
        }
    }
}
