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

        public IDataResult<IList<Report>> GetAll()
        {
            var query= _reportRepository.GetAll().ToList();
            return new SuccessDataResult<List<Report>>(query, "Raporlar Başarıyla Alındı");

        }

        public IDataResult<Report> Get(Guid id)
        {
            var query =  _reportRepository.Get(id);
            return new SuccessDataResult<Report>(query, "Rapor Başarıyla Alındı");

        }

        public async Task<IDataResult<Report>> AddAsync(Report report)
        {
            var query = await _reportRepository.AddAsync(report);
            return new SuccessDataResult<Report>(query, "Rapor Başarıyla Alındı");

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
