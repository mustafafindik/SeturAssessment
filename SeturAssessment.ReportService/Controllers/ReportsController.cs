using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeturAssessment.ReportService.Business.Abstract;
using SeturAssessment.ReportService.Entities.Concrete;
using SeturAssessment.ReportService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportManager _reportManager;

        public ReportsController(IReportManager reportManager)
        {
            _reportManager = reportManager;
        }


        [HttpGet]
        public IActionResult Get()
        {

            var result = _reportManager.GetAll();
             return  Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _reportManager.Get(id);
            return Ok(result);

        }


        [HttpPost("add")]
        public async Task<IActionResult> Add()
        {
            var report = new Report() {RequestDate = DateTime.Now, ReportStatusId  =1};
            var result = await _reportManager.AddAsync(report);

            return Ok(result);


        }
    }
}
