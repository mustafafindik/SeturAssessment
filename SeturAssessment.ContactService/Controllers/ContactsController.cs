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
using SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactManager _contactManager;
        private readonly IMapper _mapper;
        private IMessageBrokerHelper _messageBrokerHelper;

        public ContactsController(IContactManager contactManager, IMapper mapper, IMessageBrokerHelper messageBrokerHelper)
        {
            _contactManager = contactManager;
            _mapper = mapper;
            _messageBrokerHelper = messageBrokerHelper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _messageBrokerHelper.QueueMessage("Deneme Mesajı");

            var result = _contactManager.GetAll();
            if (result.IsSuccess)
            {
                var resultDto = _mapper.Map<List<ContactListDto>>(result.Data);
                return Ok(resultDto);
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _contactManager.Get(id);
            if (result.IsSuccess)
            {
                var resultDto = _mapper.Map<ContactListDto>(result.Data);
                return Ok(resultDto);
            }
            return BadRequest(new { Message = result.Message });

        }

        [HttpPost("add")]


        public IActionResult Add(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var result =  _contactManager.Add(contact);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });



        }

        [HttpPost("update")]


        public IActionResult Update([FromBody] ContactDto contactDto)
        {

            var contact = _mapper.Map<Contact>(contactDto);
            var result = _contactManager.Update(contact);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }


        [HttpPost("delete")]

        public IActionResult Delete(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var result =_contactManager.Delete(contact.Id);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
         }
    }
}
