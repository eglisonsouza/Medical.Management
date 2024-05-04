using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> AddAsync(Doctor entity);
        Task<Doctor?> GetAsync(Guid id);
        Task UpdateAsync(Doctor entity);
        bool CpfIsExist(string cpf);
        Task SaveAsync();
    }
}
