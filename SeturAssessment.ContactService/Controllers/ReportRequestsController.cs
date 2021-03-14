using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRequestsController : ControllerBase
    {
        private readonly IReportRequestManager _reportRequestManager;
        private readonly IMessageBrokerHelper _messageBrokerHelper;
        public ReportRequestsController(IReportRequestManager reportRequestManager, IMessageBrokerHelper messageBrokerHelper)
        {
            _reportRequestManager = reportRequestManager;
            _messageBrokerHelper = messageBrokerHelper;
        }

        // Kuyruktan veri geldiğinde buradan Rapor içeriği alıcak ve Rapor İçeriğine kaydedilecek
        [HttpGet("GetReportBody")]
        public async Task<IActionResult> Get()
        {
            var result = await _reportRequestManager.GetAll();
            if (result.IsSuccess)
            {
                 return Ok(result.Data);
            }
            return BadRequest(new { Message = result.Message });
        }

        //Bu Post edildiğinde içeriği boş bir db eklenecek ve Mesaj olarak kuyguga iletilecek.
        [HttpPost("RequestReport")]
        public async Task<IActionResult> RequestReport()
        {
            var result = await _reportRequestManager.SendReportRequestAsync();
            if (result.IsSuccess)
            {
                var json = JsonConvert.SerializeObject(result.Data);
                _messageBrokerHelper.QueueMessage(result.Data.Id.ToString());
                return Ok(result.Message);

            }
            return BadRequest(new { Message = result.Message });

        }
    }
}
