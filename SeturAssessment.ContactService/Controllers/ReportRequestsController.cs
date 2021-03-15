using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.ViewModels;
using SeturAssessment.ContactService.Utilities.Constants;
using SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRequestsController : ControllerBase
    {
        private readonly IMessageBrokerHelper _messageBrokerHelper;
        private readonly IContactDetailManager _contactDetailManager;
        public ReportRequestsController(IMessageBrokerHelper messageBrokerHelper, IContactDetailManager contactDetailManager)
        {
            _messageBrokerHelper = messageBrokerHelper;
            _contactDetailManager = contactDetailManager;
        }

   

        //Bu Post edildiğinde içeriği boş bir db eklenecek ve Mesaj olarak kuyguga iletilecek.
        [HttpPost("RequestReport")]
        public async Task<IActionResult> RequestReport()
        {
            var result = await _contactDetailManager.GetContactDetailsAsync();
            if (result.IsSuccess)
            {
                ReportRequestModel reportRequestModel = new ReportRequestModel();
                reportRequestModel.ContactDetails = result.Data.ToList();;
                _messageBrokerHelper.QueueMessage(reportRequestModel);
                return Ok(Messages.ReportRequestCreated);
            }
            return BadRequest(new { Message = result.Message });
   

        }

        [HttpPost("RequestReport/{location}")]
        public async Task<IActionResult> RequestReportWithLocation(string location)
        {
            var result = await _contactDetailManager.GetContactDetailsAsync();
            if (result.IsSuccess)
            {
                ReportRequestModelWithLocation reportRequestModel = new ReportRequestModelWithLocation();
                reportRequestModel.ContactDetails = result.Data.ToList();
                reportRequestModel.location = location;
                _messageBrokerHelper.QueueMessage(reportRequestModel);
                return Ok($"{location} {Messages.ReportRequestCreatedForLocation}");
            }
            return BadRequest(new { Message = result.Message });

        }
    }
}
