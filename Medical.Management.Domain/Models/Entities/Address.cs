using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Management.Domain.Models.Entities
{
    public sealed class Address : BaseEntity
    {
        [Column]
        [Required]
        [LengthAttribute(1, 30)]
        public string Street { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(1, 10)]
        public string Number { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(1, 30)]
        public string City { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(1, 30)]
        public string Zone { get; private set; }
        [Column]
        [Required]
        [LengthAttribute(1, 30)]
        public string Country { get; private set; }
        [Column]
        [Required]
        public Guid PeopleId { get; private set; }

        public People People { get; private set; }

        public Address(string street, string number, string city, string zone, string country, Guid peopleId)
        {
            Street = street;
            Number = number;
            City = city;
            Zone = zone;
            Country = country;
            PeopleId = peopleId;
        }
    }
}
