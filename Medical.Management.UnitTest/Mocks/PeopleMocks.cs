using Medical.Management.Application.Models.InputModels;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.UnitTest.Mocks
{
    public static class PeopleMocks
    {
        public static People GetPeopleEntity()
        {
            return new People
            {
                BirthDate = DateTime.Now,
                BloodType = BloodType.ANegative,
                Cpf = "10239439485",
                Email = "eglison.souza@gmail.com",
                LastName = "Souza",
                Name = "Eglison"
            };
        }

        public static PeopleInputModel GetPeopleInputModel()
        {
            return new PeopleInputModel()
            {
                Name = "name",
                LastName = "lastName",
                BirthDate = DateTime.Now,
                Phone = "phone",
                Email = "email",
                Cpf = "cpf",
                BloodType = BloodType.AbPositive
            };

        }
    }
}
