using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;

namespace Medical.Management.Domain.Service
{
    public interface IServiceDoctorService
    {
        Task<ServiceDoctorViewModel> AddAsync(ServiceDoctorInputModel model);
        Task<List<ServiceDoctorViewModel>> AddRangeAsync(List<ServiceDoctorInputModel> models);
        Task<ServiceDoctorViewModel> GetAsync(Guid id);
        Task<List<ServiceDoctorViewModel>> GetByDoctorIdAsync(Guid doctorId);
        void Update(ServiceDoctorInputModel model, Guid id);
    }
}
