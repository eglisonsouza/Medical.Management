using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class Doctor(Guid peopleId, string specialty, string crmRegistration) : BaseEntity
    {
        public People? People { get; set; }

        [Column][Required] public Guid PeopleId { get; private set; } = peopleId;

        [Column][Required][LengthAttribute(1, 30)] public string Specialty { get; private set; } = specialty;

        [Column(TypeName = "char(10)")][Required][LengthAttribute(10, 10)] public string CrmRegistration { get; private set; } = crmRegistration;

        public List<ProceduralMedical> Services { get; private set; } = default!;

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
