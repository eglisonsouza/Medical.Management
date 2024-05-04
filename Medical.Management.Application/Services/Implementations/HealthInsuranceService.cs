using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Exceptions;
using Medical.Management.Domain.Repositories;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Application.Services.Implementations
{
    public class HealthInsuranceService(IHealthInsuranceRepository repository, IMapper mapper, NotificationContext notification) : IHealthInsuranceService
    {
        private readonly IHealthInsuranceRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        private NotificationContext _notificationContext = notification;

        public async Task<HealthInsuranceViewModel> AddAsync(HealthInsuranceInputModel model)
        {
            var healthInsurance = await _repository.AddAsync(model.ToEntity());

            return _mapper.Map<HealthInsuranceViewModel>(healthInsurance);
        }

        public async Task<HealthInsuranceViewModel> GetAsync(Guid id)
        {
            var healthInsurance = await _repository.GetAsync(id)
                ?? throw new HealthInsuranceNotFoundException();

            return _mapper.Map<HealthInsuranceViewModel>(healthInsurance);
        }

        public IList<HealthInsuranceViewModel> GetAll()
        {
            return _repository.GetAll().Select(HealthInsuranceViewModel.FromEntity).ToList();
        }

        public async Task UpdateAsync(HealthInsuranceInputModel model, Guid id)
        {
            var healthInsurance = await _repository.GetAsync(id)
                ?? throw new HealthInsuranceNotFoundException();

            healthInsurance.UpdateName(model.Name);

            _repository.Update(healthInsurance);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
