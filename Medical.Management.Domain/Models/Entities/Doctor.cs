namespace Medical.Management.Domain.Models.Entities
{
    public sealed class Doctor : BaseEntity
    {
        public People? People { get; set; }

        public Guid PeopleId { get; set; }
        public string Specialty { get; set; }
        public string CrmRegistration { get; set; }
        public List<ProceduralMedical> ProceduralMedicals { get; set; }

        public Doctor UpdateCrmRegistration(string crmRegistration)
        {
            CrmRegistration = crmRegistration;
            return this;
        }

        public Doctor UpdateSpecialty(string specialty)
        {
            Specialty = specialty;
            return this;
        }
    }
}
