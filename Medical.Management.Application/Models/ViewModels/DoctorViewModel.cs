using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.ViewModels
{
    public class DoctorViewModel
    {
        public Guid Id { get; set; }
        public PeopleViewModel People { get; set; }
        public string Specialty { get; set; }
        public string CrmRegistration { get; set; }
    }
}
