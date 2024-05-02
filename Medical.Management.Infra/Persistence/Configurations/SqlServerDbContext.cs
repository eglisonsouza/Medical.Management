using Medical.Management.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Management.Infra.Persistence.Configurations
{
    [ExcludeFromCodeCoverage]
    public sealed class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HealthInsurance> HealthInsurances { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<ProceduralMedical> ProceduralMedicals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
