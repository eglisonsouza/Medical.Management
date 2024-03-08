namespace Medical.Management.Domain.Models.Entities
{
    public sealed class Doctor : BaseEntity
    {
        public People People { get; private set; }
        public Guid PeopleId { get; private set; }
        public string Specialty { get; private set; }
        public string CrmRegistration { get; private set; }
        public List<Service> Services { get; private set; }
    }
}
