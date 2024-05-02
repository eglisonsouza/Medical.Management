using Medical.Management.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Management.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.Weight).IsRequired();

            builder.HasOne(x => x.People)
                .WithOne();

        }
    }
}
