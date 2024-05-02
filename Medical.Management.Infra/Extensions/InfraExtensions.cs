using Medical.Management.Domain.Repositories;
using Medical.Management.Infra.Persistence.Configurations;
using Medical.Management.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Essentials.HealthCheck.SqlServer.DependencyInjection;

namespace Medical.Management.Infra.Extensions
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddHealthChecksInfra(configuration);
            services.AddRepositories();
            return services;
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection"),
                    b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));
        }

        private static void AddHealthChecksInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHealthChecks()
                .AddSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection")!);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IHealthInsuranceRepository, HealthInsuranceRepository>();
            services.AddScoped<IProceduralMedicalRepository, ProceduralMedicalRepository>();

        }
    }
}
