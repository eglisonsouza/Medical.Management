using System.ComponentModel.DataAnnotations;

namespace Medical.Management.Domain.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key] public Guid Id { get; private set; } = new Guid();
    }
}
