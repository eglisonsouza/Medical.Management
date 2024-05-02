using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Repositories;

namespace Medical.Management.Application.Services.Implementations
{
    public class DoctorService(IDoctorRepository repository, IMapper mapper) : IDoctorService
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<DoctorViewModel> AddAsync(DoctorInputModel model)
        {
            var doctor = await _repository.AddAsync(_mapper.Map<Doctor>(model));

            return _mapper.Map<DoctorViewModel>(doctor);
        }

        public async Task<DoctorViewModel> GetAsync(Guid id)
        {
            var doctor = await _repository.GetAsync(id)
                ?? throw new DoctorNotFoundException();

            return _mapper.Map<DoctorViewModel>(doctor);
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
