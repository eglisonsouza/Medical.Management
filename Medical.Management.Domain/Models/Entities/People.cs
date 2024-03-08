using Medical.Management.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class People : BaseEntity
    {
        [Column]
        [Required]
        [LengthAttribute(1, 100)]
        public string Name { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(1, 100)]
        public string LastName { get; private set; }
        [Column]
        [Required]
        public DateTime BirthDate { get; private set; }
        [Column]
        [LengthAttribute(1, 14)]
        public string Phone { get; private set; }
        [Column]
        [LengthAttribute(1, 100)]
        public string Email { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(11, 11)]
        public string Cpf { get; private set; }
        [Column]
        [Required]
        public BloodType BloodType { get; private set; }
        public Address Address { get; private set; }
    }
}
