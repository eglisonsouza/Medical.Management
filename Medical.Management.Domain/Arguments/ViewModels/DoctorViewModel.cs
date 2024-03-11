using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Arguments.ViewModels
{
    public class DoctorViewModel(Guid id, PeopleViewModel people, string specialty, string crmRegistration)
    {
        public Guid Id { get; set; } = id;
        public PeopleViewModel People { get; set; } = people;
        public string Specialty { get; set; } = specialty;
        public string CrmRegistration { get; set; } = crmRegistration;

        public static DoctorViewModel FromEntity(Doctor entity)
        {
            return new DoctorViewModel
                (
                    entity.Id,
                    PeopleViewModel.FromEntity(entity.People),
                    entity.Specialty,
                    entity.CrmRegistration
                );
        }
    }
}
