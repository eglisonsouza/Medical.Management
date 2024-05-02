using Medical.Management.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Management.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class ProceduralMedicalConfiguration : IEntityTypeConfiguration<ProceduralMedical>
    {
        public void Configure(EntityTypeBuilder<ProceduralMedical> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.DurationInMinutes).IsRequired();

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.ProceduralMedicals)
                .HasForeignKey(x => x.DoctorId);

        }
    }
}
