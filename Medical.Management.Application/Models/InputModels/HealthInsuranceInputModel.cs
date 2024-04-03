using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.InputModels
{
    public class HealthInsuranceInputModel
    {
        public string Name { get; set; }

        public HealthInsurance ToEntity()
        {
            return new HealthInsurance(Name);
        }
    }
}
