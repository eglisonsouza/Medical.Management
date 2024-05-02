using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.Mappings
{
    public class PeopleMapping : Profile
    {
        public PeopleMapping()
        {
            CreateMap<People, PeopleViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name,
                    map => map.MapFrom(src => src.Name))
                .ForMember(dst => dst.LastName,
                    map => map.MapFrom(src => src.LastName))
                .ForMember(dst => dst.BirthDate,
                    map => map.MapFrom(src => src.BirthDate))
                .ForMember(dst => dst.Phone,
                    map => map.MapFrom(src => src.Phone))
                .ForMember(dst => dst.Email,
                    map => map.MapFrom(src => src.Email))
                .ForMember(dst => dst.Cpf,
                    map => map.MapFrom(src => src.Cpf))
                .ForMember(dst => dst.BloodType,
                    map => map.MapFrom(src => src.BloodType));
        }
    }
}
