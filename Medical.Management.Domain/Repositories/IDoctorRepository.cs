using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<People> AddAsync(People entity);
        Task<Doctor> AddAsync(Doctor entity);
        Task<Doctor?> GetAsync(Guid id);
        Task UpdateAsync(Doctor entity);
        bool CpfIsExist(string cpf);
        Task SaveAsync();
    }
}
