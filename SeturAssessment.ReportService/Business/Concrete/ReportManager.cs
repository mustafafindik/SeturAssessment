using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeturAssessment.ReportService.Business.Abstract;
using SeturAssessment.ReportService.DataAccess.Abstract;
using SeturAssessment.ReportService.Entities.Concrete;
using SeturAssessment.ReportService.Utilities.Results;

namespace SeturAssessment.ReportService.Business.Concrete
{
    public class ReportManager : IReportManager
    {
        private readonly IReportRepository _reportRepository;
        private readonly IConfiguration _configuration;
        public ReportManager(IReportRepository reportRepository, IConfiguration configuration)
        {
            _reportRepository = reportRepository;
            _configuration = configuration;
        }

        public IList<Report> GetAll()
        {
            return _reportRepository.GetAll().ToList();
        }

        public Report Get(Guid id)
        {
            return _reportRepository.Get(id);
        }

        public async Task<Report> AddAsync(Report report)
        {
            var result = await _reportRepository.AddAsync(report);
            return result;
        }

        public async Task UpdateAsync(Report report)
        {
            await _reportRepository.UpdateAsync(report);
        }

        public async Task<IDataResult<string>> GetReportBodyAsync()
        {
            var apiOptions = _configuration.GetSection("ContactApi").Get<ApiOptions>();
            HttpClient http = new HttpClient
            {
                BaseAddress = new Uri(apiOptions.Url)
            };
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var request = await http.GetAsync(apiOptions.Endpoint);
            var content = await request.Content.ReadAsStringAsync();

            if (request.IsSuccessStatusCode)
            {
                return new SuccessDataResult<string>(content, "Rapor İçeriği Başarıyla Alındı");
            }
            else
            {
                return new ErrorDataResult<string>("Rapor İçeriği Alınırken  Bir Hata Oluştu");
            }


        }




        public class ApiOptions
        {
            public string Url { get; set; }
            public string Endpoint { get; set; }
        }
    }
}
