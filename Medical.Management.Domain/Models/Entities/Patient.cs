namespace Medical.Management.Domain.Models.Entities
{
    public class Patient : BaseEntity
    {
        public People People { get; set; }
        public Guid PeopleId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Patient UpdateHeight(double height)
        {
            Height = height;
            return this;
        }

        public Patient UpdateWeight(double weight)
        {
            Weight = weight;
            return this;
        }
    }
}
