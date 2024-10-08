using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.UnitTest.Mocks
{
    public static class DoctorMocks
    {
        public static DoctorInputModel GetDoctorValidInputModel()
        {
            return new DoctorInputModel()
            {
                CrmRegistration = "23432",
                Specialty = "Farmacia",
                People = new PeopleInputModel()
                {
                    BirthDate = new DateTime(2000, 02, 23),
                    BloodType = BloodType.APositive,
                    Cpf = "12345678901",
                    Email = "eg@eg.com",
                    LastName = "Last",
                    Name = "Fist",
                    Phone = "707060"
                }
            };
        }

        public static DoctorInputModel GetDoctorInvalidInputModel()
        {
            var today = DateTime.Now;
            return new DoctorInputModel()
            {
                CrmRegistration = "23432",
                Specialty = "Farmacia",
                People = new PeopleInputModel()
                {
                    BirthDate = new DateTime(today.Year - 1, today.Month, today.AddDays(1).Day),
                    BloodType = BloodType.APositive,
                    Cpf = "12345678901",
                    Email = "eg@eg.com",
                    LastName = "Last",
                    Name = "Fist",
                    Phone = "707060"
                }
            };
        }

        public static Doctor GetDoctorEntity()
        {
            return new Doctor()
            {
                Specialty = "Test",
                CrmRegistration = "Test",
                People = PeopleMocks.GetPeopleEntity()
            };
        }

        public static DoctorViewModel GetDoctorViewModel()
        {
            return new DoctorViewModel
            {
                Id = Guid.NewGuid(),
                CrmRegistration = "23432",
                Specialty = "Farmacia",
                People = new PeopleViewModel
                {
                    Id = Guid.NewGuid(),
                    BirthDate = new DateTime(2000, 02, 23),
                    BloodType = BloodType.APositive,
                    Cpf = "12345678901",
                    Email = "eg@eg.com",
                    LastName = "Last",
                    Name = "Fist",
                    Phone = "707060"
                }
            };
        }
    }
}
