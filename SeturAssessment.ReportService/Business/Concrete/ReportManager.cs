using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeturAssessment.ContactService.Entities.ViewModels;
using SeturAssessment.ReportService.Business.Abstract;
using SeturAssessment.ReportService.DataAccess.Abstract;
using SeturAssessment.ReportService.Entities.Concrete;
using SeturAssessment.ReportService.Entities.Dto;
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
            var query = _reportRepository.GetAll().ToList();
            return new SuccessDataResult<List<Report>>(query, "Raporlar Başarıyla Alındı");

        }

        public IDataResult<Report> Get(Guid id)
        {
            var query = _reportRepository.Get(id);
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

        public async Task<IDataResult<string>> GetReportBodyAsync(ResponseModel model)
        {
           
            IList<ReportBody> query = new List<ReportBody>();
            var locationList = model.ContactDetails.Select(q => q.Location).Distinct();
            foreach (var location in locationList.Where(q=>model.location == null || q==model.location ))
            {
                var x = new ReportBody
                {
                    Location = location,
                    ContactCount = model.ContactDetails.Count(q => q.Location==location),
                    PhoneNumberCount = model.ContactDetails.Where(q=>!String.IsNullOrEmpty(q.Phone)).Count(q=>q.Location==location),
                };
                query.Add(x);
            }
         

            return new SuccessDataResult<string>(JsonConvert.SerializeObject(query), "Rapor İçeriği Oluştu");


        }





    }
}
