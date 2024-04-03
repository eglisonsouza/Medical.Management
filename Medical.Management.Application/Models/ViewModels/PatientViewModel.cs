using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.ViewModels
{
    public class PatientViewModel
    {
        public Guid Id { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public PeopleViewModel People { get; set; }

        public static PatientViewModel FromEntity(Patient entity)
        {
            return new PatientViewModel { Id = entity.Id, Height = entity.Height, Weight = entity.Weight, People = PeopleViewModel.FromEntity(entity.People) };
        }
    }
}
