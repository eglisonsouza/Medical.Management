using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Exceptions;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;

namespace Medical.Management.Application.Services.Implementations
{
    public class PatientService(IPatientRepository repository, IMapper mapper) : IPatientService
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<PatientViewModel> AddAsync(PatientInputModel model)
        {
            var patient = await _repository.AddAsync(_mapper.Map<Patient>(model));

            return _mapper.Map<PatientViewModel>(patient);
        }

        public async Task<PatientViewModel> GetAsync(Guid id)
        {
            var patient = await _repository.GetAsync(id)
                ?? throw new PatientNotFoundException();

            return _mapper.Map<PatientViewModel>(patient);
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
