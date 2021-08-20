using System;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace PersonApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(p => p.FullName,
                    opt
                        => opt.MapFrom(
                            x => string.Join(" ", x.FName, x.LName)))
                .ForMember(p => p.Birth_Date, 
                    opt => opt.MapFrom(
                        x => x.Birth_Date.ToString("yyyy-MM-dd")));
        }
    }
}