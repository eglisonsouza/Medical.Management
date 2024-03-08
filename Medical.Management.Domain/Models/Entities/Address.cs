namespace Medical.Management.Domain.Models.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string Zone { get; private set; }
        public string Coutry { get; private set; }
    }
}
