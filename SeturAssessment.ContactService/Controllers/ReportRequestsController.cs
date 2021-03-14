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
using SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRequestsController : ControllerBase
    {
        private readonly IReportRequestManager _reportRequestManager;
        private readonly IMessageBrokerHelper _messageBrokerHelper;
        private readonly IContactManager _contactManager;
        public ReportRequestsController(IReportRequestManager reportRequestManager, IMessageBrokerHelper messageBrokerHelper, IContactManager contactManager)
        {
            _reportRequestManager = reportRequestManager;
            _messageBrokerHelper = messageBrokerHelper;
            _contactManager = contactManager;
        }

   

        //Bu Post edildiğinde içeriği boş bir db eklenecek ve Mesaj olarak kuyguga iletilecek.
        [HttpPost("RequestReport")]
        public async Task<IActionResult> RequestReport()
        {
            var result = await _contactManager.GetAllAsync();
            if (result.IsSuccess)
            {
                ReportRequestModel reportRequestModel = new ReportRequestModel();
                reportRequestModel.Contacts = result.Data.ToList();;
                _messageBrokerHelper.QueueMessage(reportRequestModel);
                return Ok("Rapor Talebi Oluşturuldu");
            }
            return BadRequest(new { Message = result.Message });
   

        }

        [HttpPost("RequestReport/{location}")]
        public async Task<IActionResult> RequestReport(string location)
        {
            var result = await _contactManager.GetAllAsync();
            if (result.IsSuccess)
            {
                ReportRequestModelWithLocation reportRequestModel = new ReportRequestModelWithLocation();
                reportRequestModel.Contacts = result.Data.ToList();
                reportRequestModel.location = location;
                _messageBrokerHelper.QueueMessage(reportRequestModel);
                return Ok($"{location} için Rapor Talebi Oluşturuldu");
            }
            return BadRequest(new { Message = result.Message });

        }
    }
}
