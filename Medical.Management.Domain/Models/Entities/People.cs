using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class People : BaseEntity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public BloodType BloodType { get; private set; }
        public Address Address { get; private set; }
    }
}
