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
        private readonly ILocationManager _locationManager;
        private readonly IMapper _mapper;


        public ContactDetailsController(IEmailManager emailManager, IPhoneNumberManager phoneNumberManager, IMapper mapper, ILocationManager locationManager)
        {
            _emailManager = emailManager;
            _phoneNumberManager = phoneNumberManager;
            _mapper = mapper;
            _locationManager = locationManager;
        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation([FromBody]  ContactLocationAddDto contactLocationAddDto )
        {
            _locationManager.Add(contactLocationAddDto);
            return Ok();
        }

        [HttpPost("UpdateLocation")]
        public IActionResult UpdateLocation([FromBody] ContactLocationDto contactLocationDto)
        {
            _locationManager.Update(contactLocationDto);
            return Ok();
        }

        [HttpPost("DeleteLocation")]
        public IActionResult DeleteLocation([FromBody] ContactLocationDto contactLocationDto)
        {

            var contactLocation = _mapper.Map<ContactLocation>(contactLocationDto);
            _locationManager.Delete(contactLocation);
            return Ok();
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
