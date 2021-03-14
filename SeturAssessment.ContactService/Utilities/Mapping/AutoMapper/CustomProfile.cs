using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SeturAssessment.ContactService.Entities.Concrete;
using SeturAssessment.ContactService.Entities.Dto;

namespace SeturAssessment.ContactService.Utilities.Mapping.AutoMapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Contact, ContactListDto>()
                .ForMember(dest => dest.ContactDetail, opt =>
                       opt.MapFrom(a => a.ContactDetails.Select(q => new ContactDetailDto(){Id = q.Id, Phone =q.Phone,Email = q.Email,Location = q.Location}).ToArray())) ;

            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<ContactDetail, ContactDetailDto>().ReverseMap();



        }
    }
}
