namespace Medical.Management.Domain.Models.Entities
{
    public class HealthInsurance : BaseEntity
    {
        public string Name { get; set; }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
