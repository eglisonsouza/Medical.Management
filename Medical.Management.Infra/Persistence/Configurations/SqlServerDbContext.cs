using Medical.Management.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medical.Management.Infra.Persistence.Configurations
{
    public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HealthInsurance> HealthInsurances { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
