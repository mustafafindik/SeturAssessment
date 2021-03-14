using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using SeturAssessment.ReportService.Business.Abstract;
using SeturAssessment.ReportService.Entities.Concrete;
using SeturAssessment.ReportService.Entities.Dto;
using SeturAssessment.ReportService.Utilities.MessageBrokers.RabbitMq;

namespace SeturAssessment.ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportManager _reportManager;
        private readonly IMapper _mapper;

        public ReportsController(IReportManager reportManager, IMapper mapper)
        {
            _reportManager = reportManager;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {

            var result = _reportManager.GetAll();
            if (result.IsSuccess)
            {
                var resultDto = _mapper.Map<List<ReportDto>>(result.Data.ToList());

                return Ok(resultDto);
            }
            return BadRequest(new { Message = result.Message });
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _reportManager.Get(id);
             if (result.IsSuccess)
            {
                var resultDto = _mapper.Map<ReportDto>(result.Data);
                return Ok(resultDto);
            }
            return BadRequest(new { Message = result.Message });

        }


        [HttpPost("add")]
        public async Task<IActionResult> Add()
        {
            var report = new Report() {RequestDate = DateTime.Now, ReportStatusId  =1};
            var result = await _reportManager.AddAsync(report);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(new { Message = result.Message });
           


        }
    }
}
