using Medical.Management.Application.Models.InputModels;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.UnitTest.Mocks
{
    public static class PeopleMocks
    {
        public static People GetPeopleEntity()
        {
            return new People("name", "lastName", DateTime.Now, "phone", "email", "cpf", BloodType.AbPositive);
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
