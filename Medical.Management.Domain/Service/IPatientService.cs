using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;

namespace Medical.Management.Domain.Service
{
    public interface IPatientService
    {
        Task<PatientViewModel> AddAsync(PatientInputModel model);
        Task<PatientViewModel> GetAsync(Guid id);
        Task UpdateAsync(PatientInputModel model, Guid id);
    }
}
