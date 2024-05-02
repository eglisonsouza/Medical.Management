using Medical.Management.Application.Models.InputModels;
using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.UnitTest.Mocks
{
    public static class PatientMocks
    {
        public static PatientInputModel GetPatientInputModel()
        {
            return new PatientInputModel
            {
                Height = 100,
                Weight = 100,
                People = PeopleMocks.GetPeopleInputModel()
            };
        }

        public static Patient GetPatientEntity()
        {
            return new Patient
            {
                PeopleId = Guid.NewGuid(),
                Height = 100,
                Weight = 10,
                People = PeopleMocks.GetPeopleEntity()
            };
        }
    }
}
