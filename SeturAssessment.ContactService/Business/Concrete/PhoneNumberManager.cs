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
    public class PhoneNumberManager:IPhoneNumberManager
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberManager(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        public IDataResult<IList<Phone>> GetAll()
        {
            var query =  _phoneNumberRepository.GetAll().ToList();
            return new SuccessDataResult<List<Phone>>(query, "Telefon Numaraları Adresleri Başarıyla Alındı");

        }

        public IDataResult<Phone> Get(int id)
        {
            var query= _phoneNumberRepository.Get(q => q.Id == id);
            return new SuccessDataResult<Phone>(query, "Telefon Numarası Adresleri Başarıyla Alındı");

        }

        public IResult Add(Phone phone)
        {
            _phoneNumberRepository.Add(phone);
            return new SuccessResult("Telefon Numarası Başarıyla Kaydedildi.");

        }

        public IResult Update(Phone phone)
        {
            _phoneNumberRepository.Update(phone, phone.Id);
            return new SuccessResult("Telefon Numarası Başarıyla Güncellendi.");

        }

        public IResult Delete(int id)
        {
            var entity = _phoneNumberRepository.Get(q => q.Id == id);
            _phoneNumberRepository.Delete(entity, entity.Id);
            return new SuccessResult("Telefon Numarası Başarıyla Silindi.");

        }
    }
}
