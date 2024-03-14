using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Arguments.InputModels
{
    public class ServiceDoctorInputModel
    {
        public Guid DoctorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int DurationInMinutes { get; set; }

        public ServiceDoctor ToEntity()
        {
            return new ServiceDoctor(Name, Description, Value, DurationInMinutes, DoctorId);
        }
    }
}
