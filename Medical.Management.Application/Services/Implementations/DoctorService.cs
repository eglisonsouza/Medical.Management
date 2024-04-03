using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Repositories;

namespace Medical.Management.Application.Services.Implementations
{
    public class DoctorService(IDoctorRepository repository) : IDoctorService
    {
        private readonly IDoctorRepository _repository = repository;

        public async Task<DoctorViewModel> AddAsync(DoctorInputModel model)
        {
            var people = await _repository.AddAsync(model.People.ToEntity());
            var doctor = await _repository.AddAsync(model.ToEntity(people.Id));
            await _repository.SaveAsync();

            return DoctorViewModel.FromEntity(doctor);
        }

        public async Task<DoctorViewModel> GetAsync(Guid id)
        {
            var doctor = await _repository.GetAsync(id)
                ?? throw new DoctorNotFoundException();

            return DoctorViewModel.FromEntity(doctor);
        }

        public async Task UpdateAsync(DoctorInputModel model, Guid id)
        {
            var doctor = await _repository.GetAsync(id)
                ?? throw new DoctorNotFoundException();

            doctor!
                .UpdateCrmRegistration(model.CrmRegistration)
                .UpdateSpecialty(model.Specialty);

            doctor.People!
                .UpdateName(model.People.Name)
                .UpdateLastName(model.People.LastName)
                .UpdateBirthDate(model.People.BirthDate)
                .UpdatePhone(model.People.Phone)
                .UpdateEmail(model.People.Email)
                .UpdateCpf(model.People.Cpf)
                .UpdateBloodType(model.People.BloodType);

            await _repository.UpdateAsync(doctor);
        }
    }
}
