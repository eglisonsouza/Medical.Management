namespace Medical.Management.Domain.Models.Entities
{
    public class Patient : BaseEntity
    {
        public People People { get; private set; }
        public Guid PeopleId { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
    }
}
