namespace Medical.Management.Domain.Models.Entities
{
    public sealed class Service : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Decimal Value { get; private set; }
        public int DurationInMinutes { get; private set; }
    }
}
