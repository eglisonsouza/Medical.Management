using Medical.Management.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Management.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Specialty).IsRequired();
            builder.Property(x => x.CrmRegistration).IsRequired();

            builder
                .HasOne(x => x.People)
                .WithOne();

            builder.HasMany(x => x.ProceduralMedicals)
                .WithOne()
                .HasForeignKey(x => x.DoctorId);

        }
    }
}
