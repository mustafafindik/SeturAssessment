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
        private readonly IContactDetailManager _contactDetailManager;
        private readonly IMapper _mapper;

        public ContactDetailsController(IMapper mapper, IContactDetailManager contactDetailManager)
        {
            _mapper = mapper;
            _contactDetailManager = contactDetailManager;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(ContactDetailDto contactDetailDto)
        {
            var contactDetail = _mapper.Map<ContactDetail>(contactDetailDto);
            var result = await _contactDetailManager.AddAsync(contactDetail);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });



        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] ContactDetailDto contactDetailDto)
        {
            var contactDetails = _mapper.Map<ContactDetail>(contactDetailDto);
            var result = await _contactDetailManager.UpdateAsync(contactDetails);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }


        [HttpPost("delete")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _contactDetailManager.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

    }
}
