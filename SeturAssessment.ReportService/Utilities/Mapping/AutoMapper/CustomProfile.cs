using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using SeturAssessment.ReportService.Entities.Concrete;
using SeturAssessment.ReportService.Entities.Dto;

namespace SeturAssessment.ReportService.Utilities.Mapping.AutoMapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Report, ReportDto>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(a => a.ReportStatus.StatusName))
                .ForMember(dest => dest.ReportBody, opt => opt.MapFrom(a => a.GetnReportBodies().ToArray()))
                .ReverseMap();
        }
    }
}
