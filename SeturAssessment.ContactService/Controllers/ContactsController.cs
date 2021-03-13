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
        public IActionResult Get()
        {
            var result = _contactManager.GetAll();
            var resultDto = _mapper.Map<List<ContactListDto>>(result);
            return Ok(resultDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _contactManager.Get(id);
            var resultDto = _mapper.Map<ContactListDto>(result);
            return Ok(resultDto);
        }

        [HttpPost("add")]


        public IActionResult Add(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _contactManager.Add(contact);
             return Ok();
           

        }

        [HttpPost("update")]


        public IActionResult Update([FromBody] ContactDto contactDto)
        {

            var contact = _mapper.Map<Contact>(contactDto);
            _contactManager.Update(contact);
            return Ok();
        }


        [HttpPost("delete")]

        public IActionResult Delete(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _contactManager.Delete(contact.Id);
            return Ok();
        }
    }
}
