namespace Medical.Management.Domain.Models.Entities
{
    public sealed class ProceduralMedical : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int DurationInMinutes { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public ProceduralMedical UpdateDescription(string description)
        {
            Description = description;
            return this;
        }

        public ProceduralMedical UpdateDurationInMinutes(int durationInMinutes)
        {
            DurationInMinutes = durationInMinutes;
            return this;
        }

        public ProceduralMedical UpdateName(string name)
        {
            Name = name;
            return this;
        }

        public ProceduralMedical UpdateValue(decimal value)
        {
            Value = value;
            return this;
        }
    }
}
