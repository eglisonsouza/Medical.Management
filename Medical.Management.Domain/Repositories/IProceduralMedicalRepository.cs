using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Repositories
{
    public interface IProceduralMedicalRepository
    {
        Task<ProceduralMedical> AddAsync(ProceduralMedical entity);
        Task AddRangeAsync(List<ProceduralMedical> entities);
        Task<ProceduralMedical?> GetAsync(Guid id);
        Task<List<ProceduralMedical>> GetByDoctorIdAsync(Guid doctorId);
        void Update(ProceduralMedical entity);
    }
}