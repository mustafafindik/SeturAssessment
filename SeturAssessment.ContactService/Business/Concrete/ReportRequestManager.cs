using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeturAssessment.ContactService.Business.Abstract;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.ViewModels;
using SeturAssessment.ContactService.Utilities.MessageBrokers.RabbitMq;
using SeturAssessment.ContactService.Utilities.Results;

namespace SeturAssessment.ContactService.Business.Concrete
{
    public class ReportRequestManager:IReportRequestManager
    {
        private readonly IReportRequestRepository _reportRequestRepository;
        private readonly IConfiguration _configuration;

        public ReportRequestManager(IReportRequestRepository reportRequestRepository, IConfiguration configuration)
        {
            _reportRequestRepository = reportRequestRepository;
            _configuration = configuration;
        }

        
    }
}
