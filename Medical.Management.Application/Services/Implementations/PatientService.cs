using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Repositories;

namespace Medical.Management.Application.Services.Implementations
{
    public class PatientService(IPatientRepository repository) : IPatientService
    {
        private readonly IPatientRepository _repository = repository;

        public async Task<PatientViewModel> AddAsync(PatientInputModel model)
        {
            var people = await _repository.AddAsync(model.People.ToEntity());
            var patient = await _repository.AddAsync(model.ToEntity(people.Id));
            await _repository.SaveAsync();

            return PatientViewModel.FromEntity(patient);
        }

        public async Task<PatientViewModel> GetAsync(Guid id)
        {
            var patient = await _repository.GetAsync(id)
                ?? throw new PatientNotFoundException();

            return PatientViewModel.FromEntity(patient);
        }

        public async Task UpdateAsync(PatientInputModel model, Guid id)
        {
            var patient = await _repository.GetAsync(id)
                ?? throw new PatientNotFoundException();

            patient
                .UpdateHeight(model.Height)
                .UpdateWeight(model.Weight);

            patient.People
                .UpdateName(model.People.Name)
                .UpdateLastName(model.People.LastName)
                .UpdateBirthDate(model.People.BirthDate)
                .UpdatePhone(model.People.Phone)
                .UpdateEmail(model.People.Email)
                .UpdateCpf(model.People.Cpf)
                .UpdateBloodType(model.People.BloodType);

            await _repository.UpdateAsync(patient);
        }
    }
}
