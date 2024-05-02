namespace Medical.Management.Application.Models.InputModels
{
    public class DoctorInputModel
    {
        public PeopleInputModel People { get; set; }
        public string Specialty { get; set; }
        public string CrmRegistration { get; set; }
    }
}
