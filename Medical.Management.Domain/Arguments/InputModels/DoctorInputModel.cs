using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Arguments.InputModels
{
    public class DoctorInputModel
    {
        public PeopleInputModel People { get; set; }
        public string Specialty { get; set; }
        public string CrmRegistration { get; set; }

        public Doctor ToEntity(Guid peopleId)
        {
            return new Doctor(peopleId, Specialty, CrmRegistration);
        }

    }
}
