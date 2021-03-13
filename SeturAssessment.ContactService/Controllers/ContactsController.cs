using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SeturAssessment.ContactService.Business.Abstract;
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
            var resultDto = _mapper.Map<List<ContactDto>>(result);
            return Ok(resultDto);
        }
    }
}
