using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Business.Concrete
{
    public class PhoneNumberManager:IPhoneNumberManager
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberManager(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        public IList<Phone> GetAll()
        {
            return _phoneNumberRepository.GetAll().ToList();
        }

        public Phone Get(int id)
        {
            return _phoneNumberRepository.Get(q => q.Id == id);
        }

        public void Add(Phone phone)
        {
            _phoneNumberRepository.Add(phone);
        }

        public void Update(Phone phone)
        {
            _phoneNumberRepository.Update(phone, phone.Id);
        }

        public void Delete(int id)
        {
            var entity = _phoneNumberRepository.Get(q => q.Id == id);
            _phoneNumberRepository.Update(entity, entity.Id);
        }
    }
}
