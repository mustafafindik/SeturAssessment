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
    public class EmailManager : IEmailManager
    {
        private readonly IEmailRepository _emailRepository;

        public EmailManager(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }


        public IDataResult<IList<Email>> GetAll()
        {
            var query= _emailRepository.GetAll().ToList();
            return new SuccessDataResult<List<Email>>(query, "Mail Adresleri Başarıyla Alındı");

        }

        public IDataResult<Email> Get(int id)
        {
            var query = _emailRepository.Get(q => q.Id == id);
            return new SuccessDataResult<Email>(query, "Mail Adresi Başarıyla Alındı");
        }

        public IResult Add(Email email)
        {
            _emailRepository.Add(email);
            return new SuccessResult("Mail Başarıyla Kaydedildi.");

        }

        public IResult Update(Email email)
        {
            _emailRepository.Update(email,email.Id);
            return new SuccessResult("Mail Başarıyla Güncellendi.");

        }

        public IResult Delete(int id)
        {
            var entity = _emailRepository.Get(q => q.Id == id);
            _emailRepository.Delete(entity,entity.Id);
            return new SuccessResult("Mail Başarıyla Silindi.");

        }
    }
}
