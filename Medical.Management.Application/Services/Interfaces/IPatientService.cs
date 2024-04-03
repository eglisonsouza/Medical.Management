using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;

namespace Medical.Management.Application.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientViewModel> AddAsync(PatientInputModel model);
        Task<PatientViewModel> GetAsync(Guid id);
        Task UpdateAsync(PatientInputModel model, Guid id);
    }
}
