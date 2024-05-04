using Medical.Management.Application.Models.Mappings;
using Medical.Management.Application.Services.Implementations;
using Medical.Management.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMapping();

            services.AddScoped<ResultModel>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IProceduralMedicalService, ProceduralMedicalService>();
            services.AddScoped<IHealthInsuranceService, HealthInsuranceService>();

            return services;
        }

        private static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DoctorMapping>();
                cfg.AddProfile<PeopleMapping>();
                cfg.AddProfile<HealthInsuranceMapping>();
            });
        }
    }
}
