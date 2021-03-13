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
            var result= _locationManager.Add(contactLocationAddDto);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpPost("UpdateLocation")]
        public IActionResult UpdateLocation([FromBody] ContactLocationDto contactLocationDto)
        {
            var result = _locationManager.Update(contactLocationDto);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpPost("DeleteLocation")]
        public IActionResult DeleteLocation([FromBody] ContactLocationDto contactLocationDto)
        {

            var contactLocation = _mapper.Map<ContactLocation>(contactLocationDto);
            var result = _locationManager.Delete(contactLocation);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }



        [HttpPost("AddEmail")]
        public IActionResult AddEmail([FromBody] EmailDto emailDto)
        {
            var email = _mapper.Map<Email>(emailDto);
            var result = _emailManager.Add(email);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpPost("UpdateEmail")]
        public IActionResult UpdateEmail([FromBody] EmailDto emailDto)
        {
            var email = _mapper.Map<Email>(emailDto);
            var result = _emailManager.Update(email);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpPost("DeleteEmail")]
        public IActionResult DeleteEmail([FromBody] EmailDto emailDto)
        {
            var email = _mapper.Map<Email>(emailDto);
            var result =  _emailManager.Delete(email.Id);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpPost("AddPhoneNumber")]
        public IActionResult AddPhoneNumber([FromBody] PhoneDto phoneNumberDto)
        {
            var phoneNumber = _mapper.Map<Phone>(phoneNumberDto);
            var result =  _phoneNumberManager.Add(phoneNumber);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpPost("UpdatePhoneNumber")]
        public IActionResult UpdatePhoneNumber([FromBody] PhoneDto phoneNumberDto)
        {
            var phoneNumber = _mapper.Map<Phone>(phoneNumberDto);
            var result =  _phoneNumberManager.Update(phoneNumber);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpPost("DeletePhoneNumber")]
        public IActionResult DeletePhoneNumber([FromBody] PhoneDto phoneNumberDto)
        {
            var phoneNumber = _mapper.Map<Phone>(phoneNumberDto);
            var result =  _phoneNumberManager.Delete(phoneNumber.Id);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }



    }
}
