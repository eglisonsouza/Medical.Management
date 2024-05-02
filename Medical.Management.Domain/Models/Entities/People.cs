using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class People : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public BloodType BloodType { get; set; }

        public People UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
            return this;
        }

        public People UpdateBloodType(BloodType bloodType)
        {
            BloodType = bloodType;
            return this;
        }

        public People UpdateCpf(string cpf)
        {
            Cpf = cpf;
            return this;
        }

        public People UpdateEmail(string email)
        {
            Email = email;
            return this;
        }

        public People UpdateLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public People UpdateName(string name)
        {
            Name = name;
            return this;
        }

        public People UpdatePhone(string phone)
        {
            Phone = phone;
            return this;
        }
    }
}
