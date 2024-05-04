using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> AddAsync(Patient entity);
        Task<Patient?> GetAsync(Guid id);
        Task UpdateAsync(Patient entity);
        Task SaveAsync();
    }
}