using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.ViewModels
{
    public class PatientViewModel
    {
        public Guid Id { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public PeopleViewModel People { get; set; }
    }
}
