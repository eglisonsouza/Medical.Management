using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class Service : BaseEntity
    {
        [Column]
        [Required]
        [LengthAttribute(1, 100)]
        public string Name { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(1, 255)]
        public string Description { get; private set; }
        [Column(TypeName = "decimal(18, 4)")]
        [Required]
        public decimal Value { get; private set; }
        [Column]
        [Required]
        [Range(minimum: 0, maximum: 999)]
        public int DurationInMinutes { get; private set; }
        [Column]
        [Required]
        public Guid DoctorId { get; private set; }

        public Doctor Doctor { get; set; }
    }
}
