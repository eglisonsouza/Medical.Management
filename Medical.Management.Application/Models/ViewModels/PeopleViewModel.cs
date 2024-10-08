using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Enums;

namespace Medical.Management.Application.Models.ViewModels;

public class PeopleViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public BloodType BloodType { get; set; }

}