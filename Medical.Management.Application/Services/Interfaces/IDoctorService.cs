using Medical.Management.Application.Models.InputModels;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Application.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<ResultModel> AddAsync(DoctorInputModel model);
        Task<ResultModel> GetAsync(Guid id);
        Task<ResultModel> UpdateAsync(DoctorInputModel model, Guid id);
    }
}
