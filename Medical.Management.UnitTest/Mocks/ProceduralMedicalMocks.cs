using Medical.Management.Application.Models.InputModels;
using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.UnitTest.Mocks
{
    public static class ProceduralMedicalMocks
    {
        public static ProceduralMedical GetProceduralMedicalEntity()
        {
            return new ProceduralMedical("name", "description", 100, 89, Guid.NewGuid());
        }

        public static ProceduralMedicalInputModel GetProceduralMedicalInputModel()
        {
            return new ProceduralMedicalInputModel
            {
                DoctorId = Guid.NewGuid(),
                Name = "Name",
                Description = "Description",
                Value = 100,
                DurationInMinutes = 79,
            };
        }
    }
}
