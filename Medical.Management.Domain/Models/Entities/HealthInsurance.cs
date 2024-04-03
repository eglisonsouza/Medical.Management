using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Management.Domain.Models.Entities
{
    public class HealthInsurance(string name) : BaseEntity
    {
        [Column]
        [Required]
        [LengthAttribute(1, 30)]
        public string Name { get; private set; } = name;

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
