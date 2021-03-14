using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
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
     

        public ContactsController(IContactManager contactManager, IMapper mapper)
        {
            _contactManager = contactManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result =await _contactManager.GetAllAsync();
            if (result.IsSuccess)
            {
                var resultDto = _mapper.Map<List<ContactListDto>>(result.Data);
                return Ok(resultDto);
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _contactManager.GetAsync(id);
            if (result.IsSuccess)
            {
                var resultDto = _mapper.Map<ContactListDto>(result.Data);
                return Ok(resultDto);
            }
            return BadRequest(new { Message = result.Message });

        }

        [HttpPost("add")]


        public async Task<IActionResult> Add(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var result = await  _contactManager.AddAsync(contact);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });



        }

        [HttpPost("update")]


        public async Task<IActionResult> Update([FromBody] ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var result = await _contactManager.UpdateAsync(contact);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }


        [HttpPost("delete")]

        public async Task<IActionResult> Delete(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var result = await _contactManager.DeleteAsync(contact.Id);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
         }
    }
}
