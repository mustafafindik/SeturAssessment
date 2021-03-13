using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.Dto;

namespace SeturAssessment.ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IEmailManager _emailManager;
        private readonly IPhoneNumberManager _phoneNumberManager;
        private readonly IMapper _mapper;


        public ContactDetailsController(IEmailManager emailManager, IPhoneNumberManager phoneNumberManager, IMapper mapper)
        {
            _emailManager = emailManager;
            _phoneNumberManager = phoneNumberManager;
            _mapper = mapper;
        }


        [HttpPost("AddEmail")]
        public IActionResult AddEmail([FromBody] EmailDto emailDto)
        {
            var email = _mapper.Map<Email>(emailDto);
            _emailManager.Add(email);
            return Ok();
        }

        [HttpPost("UpdateEmail")]
        public IActionResult UpdateEmail([FromBody] EmailDto emailDto)
        {
            var email = _mapper.Map<Email>(emailDto);
            return Ok();
        }

        [HttpPost("DeleteEmail")]
        public IActionResult DeleteEmail([FromBody] EmailDto emailDto)
        {
            var email = _mapper.Map<Email>(emailDto);
            _emailManager.Delete(email.Id);
            return Ok();
        }

        [HttpPost("AddPhoneNumber")]
        public IActionResult AddPhoneNumber([FromBody] PhoneDto phoneNumberDto)
        {
            var phoneNumber = _mapper.Map<Phone>(phoneNumberDto);
            _phoneNumberManager.Add(phoneNumber);
            return Ok();
        }

        [HttpPost("UpdatePhoneNumber")]
        public IActionResult UpdatePhoneNumber([FromBody] PhoneDto phoneNumberDto)
        {
            var phoneNumber = _mapper.Map<Phone>(phoneNumberDto);
            _phoneNumberManager.Update(phoneNumber);
            return Ok();
        }

        [HttpPost("DeletePhoneNumber")]
        public IActionResult DeletePhoneNumber([FromBody] PhoneDto phoneNumberDto)
        {
            var phoneNumber = _mapper.Map<Phone>(phoneNumberDto);
            _phoneNumberManager.Delete(phoneNumber.Id);
            return Ok();
        }
    }
}
