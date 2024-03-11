using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class ServiceDoctor(string name, string description, decimal value, int durationInMinutes, Guid doctorId) : BaseEntity
    {
        [Column]
        [Required]
        [LengthAttribute(1, 100)]
        public string Name { get; private set; } = name;
        [Column]
        [Required]
        [LengthAttribute(1, 255)]
        public string Description { get; private set; } = description;
        [Column(TypeName = "decimal(18, 4)")]
        [Required]
        public decimal Value { get; private set; } = value;
        [Column]
        [Required]
        [Range(minimum: 0, maximum: 999)]
        public int DurationInMinutes { get; private set; } = durationInMinutes;
        [Column]
        [Required]
        public Guid DoctorId { get; private set; } = doctorId;

        public Doctor Doctor { get; set; }
    }
}
