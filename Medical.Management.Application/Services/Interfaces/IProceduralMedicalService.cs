using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;

namespace Medical.Management.Application.Services.Interfaces
{
    public interface IProceduralMedicalService
    {
        Task<ProceduralMedicalViewModel> AddAsync(ProceduralMedicalInputModel model);
        Task<List<ProceduralMedicalViewModel>> AddRangeAsync(List<ProceduralMedicalInputModel> models);
        Task<ProceduralMedicalViewModel> GetAsync(Guid id);
        Task<List<ProceduralMedicalViewModel>> GetByDoctorIdAsync(Guid doctorId);
        Task Update(ProceduralMedicalInputModel model, Guid id);
    }
}
