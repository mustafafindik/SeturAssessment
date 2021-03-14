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


        [HttpPost("add/{contactId}")]
        public async Task<IActionResult> Add(Guid contactId, ContactDetailDto contactDetailDto)
        {
            var contactDetail = _mapper.Map<ContactDetail>(contactDetailDto);
            contactDetail.ContactId = contactId;
            var result = await _contactDetailManager.AddAsync(contactDetail);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });



        }

        [HttpPost("update/{contactId}")]
        public async Task<IActionResult> Update(Guid contactId, ContactDetailDto contactDetailDto)
        {
            var contactDetail = _mapper.Map<ContactDetail>(contactDetailDto);
            contactDetail.ContactId = contactId;
            var result = await _contactDetailManager.UpdateAsync(contactDetail);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }


        [HttpPost("delete/{contactDetailId}")]

        public async Task<IActionResult> Delete(Guid contactDetailId)
        {
            var result = await _contactDetailManager.DeleteAsync(contactDetailId);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

    }
}
