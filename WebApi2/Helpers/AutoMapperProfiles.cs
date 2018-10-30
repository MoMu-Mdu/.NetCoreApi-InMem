using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.DTOs;
using WebApi2.Model;

namespace WebApi2.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.FirstName, opt =>
                {
                    opt.MapFrom(src => src.GivenName);
                })
                .ForMember(dest => dest.LastName, opt =>
                {
                    opt.MapFrom(src => src.FamilyName);
                });
        }
    }
}
