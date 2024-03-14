using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.Domain.Arguments.ViewModels;

public class PeopleViewModel(Guid id, string name, string lastName, DateTime birthDate, string phone, string email, string cpf, BloodType bloodType)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string LastName { get; set; } = lastName;
    public DateTime BirthDate { get; set; } = birthDate;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
    public string Cpf { get; set; } = cpf;
    public BloodType BloodType { get; set; } = bloodType;

    public static PeopleViewModel FromEntity(People people)
    {
        return new PeopleViewModel
            (
                people.Id,
                people.Name,
                people.LastName,
                people.BirthDate,
                people.Phone,
                people.Email,
                people.Cpf,
                people.BloodType
            );
    }
}