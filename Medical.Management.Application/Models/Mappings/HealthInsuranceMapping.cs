using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.Mappings
{
    public class HealthInsuranceMapping : Profile
    {
        public HealthInsuranceMapping()
        {
            CreateMap<HealthInsuranceInputModel, HealthInsurance>()
                .ForMember(dst => dst.Name,
                    map => map.MapFrom(src => src.Name));


            CreateMap<HealthInsurance, HealthInsuranceViewModel>()
                .ForMember(dst => dst.Name,
                    map => map.MapFrom(src => src.Name))
                .ForMember(dst => dst.Id,
                    map => map.MapFrom(src => src.Id));
        }
    }
}
