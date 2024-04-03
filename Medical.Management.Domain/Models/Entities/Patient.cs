using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Management.Domain.Models.Entities
{
    public class Patient(Guid peopleId, double height, double weight) : BaseEntity
    {
        public People People { get; set; }
        [Column]
        [Required]
        public Guid PeopleId { get; private set; } = peopleId;
        [Column]
        [Required]
        public double Height { get; private set; } = height;
        [Column]
        [Required]
        public double Weight { get; private set; } = weight;

        public Patient UpdateHeight(double height)
        {
            Height = height;
            return this;
        }

        public Patient UpdateWeight(double weight)
        {
            Weight = weight;
            return this;
        }
    }
}
