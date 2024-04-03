using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Repositories;

namespace Medical.Management.Application.Services.Implementations
{
    public class HealthInsuranceService(IHealthInsuranceRepository repository) : IHealthInsuranceService
    {
        private readonly IHealthInsuranceRepository _repository = repository;

        public async Task<HealthInsuranceViewModel> AddAsync(HealthInsuranceInputModel model)
        {
            var healthInsurance = await _repository.AddAsync(model.ToEntity());

            return HealthInsuranceViewModel.FromEntity(healthInsurance);
        }

        public async Task<HealthInsuranceViewModel> GetAsync(Guid id)
        {
            var healthInsurance = await _repository.GetAsync(id)
                ?? throw new HealthInsuranceNotFoundException();

            return HealthInsuranceViewModel.FromEntity(healthInsurance);
        }

        public List<HealthInsuranceViewModel> GetAll()
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
