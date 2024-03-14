using Medical.Management.Application.Services;
using Medical.Management.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Management.IoC
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IServiceDoctorService, ServiceDoctorService>();
            services.AddScoped<IHealthInsuranceService, HealthInsuranceService>();

            return services;
        }
    }
}
