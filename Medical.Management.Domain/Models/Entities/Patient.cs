using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Management.Domain.Models.Entities
{
    public class Patient : BaseEntity
    {
        public People People { get; private set; }
        [Column]
        [Required]
        public Guid PeopleId { get; private set; }
        [Column]
        [Required]
        public double Height { get; private set; }
        [Column]
        [Required]
        public double Weight { get; private set; }
    }
}
