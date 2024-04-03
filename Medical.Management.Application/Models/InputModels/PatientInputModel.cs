using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.InputModels
{
    public class PatientInputModel
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public PeopleInputModel People { get; set; }

        public Patient ToEntity(Guid peopleId)
        {
            return new Patient(peopleId, Height, Weight);
        }
    }
}
