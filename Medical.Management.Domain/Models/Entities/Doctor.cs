using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class Doctor : BaseEntity
    {
        public People People { get; private set; }
        [Column]
        [Required]
        public Guid PeopleId { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(1, 30)]
        public string Specialty { get; private set; }
        [Column(TypeName = "char(10)")]
        [Required]
        [LengthAttribute(10, 10)]
        public string CrmRegistration { get; private set; }
        public List<Service> Services { get; private set; }
    }
}
