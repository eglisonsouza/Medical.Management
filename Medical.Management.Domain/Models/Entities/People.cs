using Medical.Management.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class People(string name, string lastName, DateTime birthDate, string phone, string email, string cpf, BloodType bloodType) : BaseEntity
    {
        [Column][Required][LengthAttribute(1, 100)] public string Name { get; private set; } = name;
        [Column][Required][LengthAttribute(1, 100)] public string LastName { get; private set; } = lastName;
        [Column][Required] public DateTime BirthDate { get; private set; } = birthDate;
        [Column][LengthAttribute(1, 14)] public string Phone { get; private set; } = phone;
        [Column][LengthAttribute(1, 100)] public string Email { get; private set; } = email;
        [Column][Required][LengthAttribute(11, 11)] public string Cpf { get; private set; } = cpf;
        [Column][Required] public BloodType BloodType { get; private set; } = bloodType;

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
