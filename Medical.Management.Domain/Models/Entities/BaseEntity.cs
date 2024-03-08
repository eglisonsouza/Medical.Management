namespace Medical.Management.Domain.Models.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
    }
}
