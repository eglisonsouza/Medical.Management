using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.Mappings
{
    public class DoctorMapping : Profile
    {
        public DoctorMapping()
        {
            CreateMap<DoctorInputModel, Doctor>()
                .ForMember(dst => dst.Specialty,
                    map => map.MapFrom(src => src.Specialty))
                .ForMember(dst => dst.CrmRegistration,
                    map => map.MapFrom(src => src.CrmRegistration))

                .ForPath(dst => dst.People.Name,
                    map => map.MapFrom(src => src.People.Name))
                .ForPath(dst => dst.People.LastName,
                    map => map.MapFrom(src => src.People.LastName))
                .ForPath(dst => dst.People.BirthDate,
                    map => map.MapFrom(src => src.People.BirthDate))
                .ForPath(dst => dst.People.Phone,
                    map => map.MapFrom(src => src.People.Phone))
                .ForPath(dst => dst.People.Email,
                    map => map.MapFrom(src => src.People.Email))
                .ForPath(dst => dst.People.Cpf,
                    map => map.MapFrom(src => src.People.Cpf))
                .ForPath(dst => dst.People.BloodType,
                    map => map.MapFrom(src => src.People.BloodType));

            CreateMap<Doctor, DoctorViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.Specialty,
                    map => map.MapFrom(src => src.Specialty))
                .ForMember(dst => dst.CrmRegistration,
                    map => map.MapFrom(src => src.CrmRegistration))
                .ForMember(dst => dst.People, map => map.MapFrom(src => src.People));
        }
    }
}
