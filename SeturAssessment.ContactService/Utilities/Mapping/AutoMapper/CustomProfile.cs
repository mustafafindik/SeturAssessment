using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.Dto;

namespace SeturAssessment.ContactService.Utilities.Mapping.AutoMapper
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
            CreateMap<Contact, ContactListDto>()
                .ForMember(dest=>dest.Emails,opt=>
                    opt.MapFrom(a =>  a.Emails.Select(q=>q.MailAddress).ToArray()))
                .ForMember(dest => dest.PhoneNumbers, opt =>
                       opt.MapFrom(a => a.PhoneNumbers.Select(q => q.PhoneNumber).ToArray()))
                .ForMember(dest => dest.Locations, opt =>
                    opt.MapFrom(a => a.ContactLocations.Select(q => q.Location.LocationName).ToArray()))
                ;

            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
            CreateMap<Phone, PhoneDto>().ReverseMap();

        }
    }
}
