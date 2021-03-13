using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Business.Concrete
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailRepository _emailRepository;

        public EmailManager(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }


        public IList<Email> GetAll()
        {
            return _emailRepository.GetAll().ToList();
        }

        public Email Get(int id)
        {
            return _emailRepository.Get(q=>q.Id==id);
        }

        public void Add(Email email)
        {
            _emailRepository.Add(email);
        }

        public void Update(Email email)
        {
            _emailRepository.Update(email,email.Id);
        }

        public void Delete(int id)
        {
            var entity = _emailRepository.Get(q => q.Id == id);

            _emailRepository.Update(entity,entity.Id);
        }
    }
}
