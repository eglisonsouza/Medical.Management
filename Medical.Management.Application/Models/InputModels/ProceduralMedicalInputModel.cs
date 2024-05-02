using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Application.Models.InputModels
{
    public class ProceduralMedicalInputModel
    {
        public Guid DoctorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int DurationInMinutes { get; set; }

        public ProceduralMedical ToEntity()
        {
            return new ProceduralMedical
            {
                Name = Name,
                Description = Description,
                Value = Value,
                DurationInMinutes = DurationInMinutes,
                DoctorId = DoctorId
            };
        }
    }
}
