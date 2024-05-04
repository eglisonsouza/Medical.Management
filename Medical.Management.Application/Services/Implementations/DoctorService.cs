using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Application.Services.Implementations
{
    public class DoctorService(IDoctorRepository repository, IMapper mapper, NotificationContext notification) : IDoctorService
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly NotificationContext _notificationContext = notification;

        public async Task<DoctorViewModel?> AddAsync(DoctorInputModel model)
        {
            ValidateAsync(model);

            if (_notificationContext.Errors.Any()) return null;

            var doctor = await _repository.AddAsync(_mapper.Map<Doctor>(model));

            return _mapper.Map<DoctorViewModel>(doctor);
        }

        public async Task<DoctorViewModel?> GetAsync(Guid id)
        {
            var doctor = await GetDoctor(id);

            return _notificationContext.Errors.Any() ? null : _mapper.Map<DoctorViewModel>(doctor);
        }

        public async Task UpdateAsync(DoctorInputModel model, Guid id)
        {
            var doctor = await GetDoctor(id);

            if (_notificationContext.Errors.Any())
            {
                return;
            }

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

        private async Task<Doctor?> GetDoctor(Guid id)
        {
            var doctor = await _repository.GetAsync(id);

            if (doctor is null)
            {
                _notificationContext.AddError("Doctor not found.");
            }

            return doctor;
        }

        private void ValidateAsync(DoctorInputModel model)
        {
            if (model.People.Cpf.Length != 11)
            {
                _notificationContext.AddError("Cpf invalid.");
            }

            if (_repository.CpfIsExist(model.People.Cpf))
            {
                _notificationContext.AddError("Cpf is exist.");
            }

            if (!IsOfAge(model.People.BirthDate))
            {
                _notificationContext.AddError("People not legal age.");
            }
        }

        private bool IsOfAge(DateTime peopleBirthDate)
        {
            var age = DateTime.Now.Year - peopleBirthDate.Year;

            if (DateTime.Now.DayOfYear < peopleBirthDate.DayOfYear)
                age = age - 1;

            return age >= 18;
        }
    }
}
