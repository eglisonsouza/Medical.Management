using Medical.Management.Application.Models.InputModels;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.UnitTest.Mocks
{
    public static class DoctorMocks
    {
        public static DoctorInputModel GetDoctorInputModel()
        {
            return new DoctorInputModel()
            {
                CrmRegistration = "23432",
                Specialty = "Farmacia",
                People = new PeopleInputModel()
                {
                    BirthDate = DateTime.UtcNow,
                    BloodType = BloodType.APositive,
                    Cpf = "23141123",
                    Email = "eg@eg.com",
                    LastName = "Last",
                    Name = "Fist",
                    Phone = "707060"
                }

            };
        }

        public static Doctor GetDoctorEntity()
        {
            return new Doctor() { People = PeopleMocks.GetPeopleEntity() };
        }
    }
}
