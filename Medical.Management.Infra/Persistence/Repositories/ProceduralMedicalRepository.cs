using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Management.Infra.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ProceduralMedicalRepository(SqlServerDbContext dbContext) : IProceduralMedicalRepository
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<ProceduralMedical> AddAsync(ProceduralMedical entity)
        {
            var result = await _dbContext.ProceduralMedicals.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task AddRangeAsync(List<ProceduralMedical> entities)
        {
            await _dbContext.ProceduralMedicals.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProceduralMedical?> GetAsync(Guid id)
        {
            return await _dbContext.ProceduralMedicals.SingleOrDefaultAsync(d => d.Id.Equals(id));
        }

        public async Task<List<ProceduralMedical>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _dbContext.ProceduralMedicals.Where(s => s.DoctorId.Equals(doctorId)).ToListAsync();
        }

        public void Update(ProceduralMedical entity)
        {
            _dbContext.ProceduralMedicals
               .Where(p => p.Id.Equals(entity.Id))
               .ExecuteUpdate(
                setters =>
                setters
                   .SetProperty(p => p.Name, entity.Name)
                   .SetProperty(p => p.Description, entity.Description)
                   .SetProperty(p => p.Value, entity.Value)
                   .SetProperty(p => p.DurationInMinutes, entity.DurationInMinutes)
               );
        }
    }
}
