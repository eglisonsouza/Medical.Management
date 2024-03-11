using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;

namespace Medical.Management.Domain.Service
{
    public interface IHealthInsuranceService
    {
        Task<HealthInsuranceViewModel> AddAsync(HealthInsuranceInputModel model);
        Task<HealthInsuranceViewModel> GetAsync(Guid id);
        List<HealthInsuranceViewModel> GetAll();
        void Update(HealthInsuranceInputModel model, Guid id);
        void Remove(Guid id);
    }
}
