using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;

namespace Medical.Management.Domain.Service
{
    public interface IDoctorService
    {
        Task<DoctorViewModel> AddAsync(DoctorInputModel model);
        Task<DoctorViewModel> GetAsync(Guid id);
        Task UpdateAsync(DoctorInputModel model, Guid id);
    }
}
