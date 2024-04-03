using Medical.Management.Application.Services.Implementations;
using Medical.Management.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Management.IoC
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IProceduralMedicalService, ProceduralMedicalService>();
            services.AddScoped<IHealthInsuranceService, HealthInsuranceService>();

            return services;
        }
    }
}
