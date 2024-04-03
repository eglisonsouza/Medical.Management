using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.ViewModels
{
    public class HealthInsuranceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static HealthInsuranceViewModel FromEntity(HealthInsurance entity)
        {
            return new HealthInsuranceViewModel { Id = entity.Id, Name = entity.Name };
        }
    }
}
