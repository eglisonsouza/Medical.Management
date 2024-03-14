using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Arguments.ViewModels
{
    public class ServiceDoctorViewModel
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int DurationInMinutes { get; set; }

        public static ServiceDoctorViewModel FromEntity(ServiceDoctor entity)
        {
            return new ServiceDoctorViewModel
            {
                Id = entity.Id,
                DoctorId = entity.DoctorId,
                Name = entity.Name,
                Description = entity.Description,
                Value = entity.Value,
                DurationInMinutes = entity.DurationInMinutes,
            };
        }
    }
}
