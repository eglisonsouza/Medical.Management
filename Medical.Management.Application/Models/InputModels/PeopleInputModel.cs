using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.Application.Models.InputModels
{
    public class PeopleInputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public BloodType BloodType { get; set; }

        public People ToEntity()
        {
            return new People(Name, LastName, BirthDate, Phone, Email, Cpf, BloodType);
        }
    }
}
