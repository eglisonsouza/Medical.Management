using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;

namespace Medical.Management.Application.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorViewModel> AddAsync(DoctorInputModel model);
        Task<DoctorViewModel> GetAsync(Guid id);
        Task UpdateAsync(DoctorInputModel model, Guid id);
    }
}
