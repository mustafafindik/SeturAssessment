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

        public async Task<IDataResult<IList<ReportBody>>> GetAll()
        {
            var query = await _reportRequestRepository.GetReportBodyAsync(); ;
            return new SuccessDataResult<IList<ReportBody>>(query, "Rapor içeriği Alındı");
        }

        public async Task<IDataResult<Report>> SendReportRequestAsync()
        {
            var apiOptions = _configuration.GetSection("ReportApi").Get<ApiOptions>();
            HttpClient http = new HttpClient
            {
                BaseAddress = new Uri(apiOptions.Url)
            };
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            

            var request = await http.PostAsync(apiOptions.Endpoint,null).ConfigureAwait(false);
            var content = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (request.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Report>(content);
                return new SuccessDataResult<Report>(result, "Talep Başarıyla Oluşturuldu");
            }
            else
            {
                return new ErrorDataResult<Report>("Talep Oluşurken Bir Hata Oluştu");
            }
        }

        public class ApiOptions
        {
            public string Url { get; set; }
            public string Endpoint { get; set; }
        }
    }
}
