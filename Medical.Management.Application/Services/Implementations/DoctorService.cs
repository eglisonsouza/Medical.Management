using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Application.Services.Implementations
{
    public class DoctorService(IDoctorRepository repository, IMapper mapper, ResultModel resultModel) : IDoctorService
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly ResultModel _resultModel = resultModel;

        public async Task<ResultModel> AddAsync(DoctorInputModel model)
        {
            ValidateAsync(model);

            var doctor = await _repository.AddAsync(_mapper.Map<Doctor>(model));

            if (!_resultModel.Errors.Any())
                _resultModel.AddResult(_mapper.Map<DoctorViewModel>(doctor));

            return _resultModel;
        }

        public async Task<ResultModel> GetAsync(Guid id)
        {
            var doctor = await GetDoctor(id);

            if (_resultModel.Errors.Any())
            {
                return _resultModel;
            }

            _resultModel.AddResult(_mapper.Map<DoctorViewModel>(doctor));

            return _resultModel;
        }

        public async Task<ResultModel> UpdateAsync(DoctorInputModel model, Guid id)
        {
            var doctor = await GetDoctor(id);

            if (_resultModel.Errors.Any())
            {
                return _resultModel;
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

            return ResultModel.WithSuccessfully();
        }

        private async Task<Doctor?> GetDoctor(Guid id)
        {
            var doctor = await _repository.GetAsync(id);

            if (doctor is null)
            {
                _resultModel.AddError("Doctor not found.");
            }

            return doctor;
        }

        private void ValidateAsync(DoctorInputModel model)
        {
            if (model.People.Cpf.Length != 11)
            {
                _resultModel.AddError("Cpf invalid.");
            }

            if (_repository.CpfIsExist(model.People.Cpf))
            {
                _resultModel.AddError("Cpf is exist.");
            }

            if (!IsOfAge(model.People.BirthDate))
            {
                _resultModel.AddError("People not legal age.");
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
