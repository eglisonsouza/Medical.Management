using Medical.Management.Application.Models.InputModels;
using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.UnitTest.Mocks
{
    public static class HealthInsuranceMocks
    {
        public static HealthInsurance GetHealthInsuranceEntity()
        {
            return new HealthInsurance
            {
                Name = "Unimed"
            };
        }

        public static HealthInsuranceInputModel GetHealthInsuranceInputModel()
        {
            return new HealthInsuranceInputModel() { Name = "Unimed" };
        }

    }
}
