using Medical.Management.Application.Models.InputModels;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Application.Services.Interfaces
{
    public interface IHealthInsuranceService
    {
        Task<ResultModel> AddAsync(HealthInsuranceInputModel model);
        Task<ResultModel> GetAsync(Guid id);
        ResultModel GetAll();
        Task UpdateAsync(HealthInsuranceInputModel model, Guid id);
        void Remove(Guid id);
    }
}
