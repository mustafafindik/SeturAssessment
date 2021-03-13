using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IEmailManager _emailManager;
        private readonly IPhoneNumberManager _phoneNumberManager;

        public ContactDetailsController(IEmailManager emailManager, IPhoneNumberManager phoneNumberManager)
        {
            _emailManager = emailManager;
            _phoneNumberManager = phoneNumberManager;
        }


        [HttpPost("AddEmail")]
        public IActionResult AddEmail([FromBody] Email email)
        {
            _emailManager.Add(email);
            return Ok();
        }

        [HttpPost("UpdateEmail")]
        public IActionResult UpdateEmail([FromBody] Email email)
        {
            _emailManager.Update(email);
            return Ok();
        }

        [HttpPost("DeleteEmail")]
        public IActionResult DeleteEmail([FromBody] Email email)
        {
            _emailManager.Delete(email.Id);
            return Ok();
        }

        [HttpPost("AddPhoneNumber")]
        public IActionResult AddPhoneNumber([FromBody] Phone phoneNumber)
        {
            _phoneNumberManager.Add(phoneNumber);
            return Ok();
        }

        [HttpPost("UpdatePhoneNumber")]
        public IActionResult UpdatePhoneNumber([FromBody] Phone phoneNumber)
        {
            _phoneNumberManager.Update(phoneNumber);
            return Ok();
        }

        [HttpPost("DeletPhoneNumber")]
        public IActionResult DeletePhoneNumber([FromBody] Phone phoneNumber)
        {
            _phoneNumberManager.Delete(phoneNumber.Id);
            return Ok();
        }
    }
}
