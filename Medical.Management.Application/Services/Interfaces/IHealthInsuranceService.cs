using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;

namespace Medical.Management.Application.Services.Interfaces
{
    public interface IHealthInsuranceService
    {
        Task<HealthInsuranceViewModel> AddAsync(HealthInsuranceInputModel model);
        Task<HealthInsuranceViewModel> GetAsync(Guid id);
        List<HealthInsuranceViewModel> GetAll();
        Task UpdateAsync(HealthInsuranceInputModel model, Guid id);
        void Remove(Guid id);
    }
}
