using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Management.Infra.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public sealed class HealthInsuranceRepository(SqlServerDbContext dbContext) : IHealthInsuranceRepository
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<HealthInsurance> AddAsync(HealthInsurance entity)
        {
            var result = await _dbContext.HealthInsurances.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<HealthInsurance?> GetAsync(Guid id)
        {
            return await _dbContext.HealthInsurances.SingleOrDefaultAsync(d => d.Id.Equals(id));
        }

        public List<HealthInsurance> GetAll()
        {
            return _dbContext.HealthInsurances.ToList();
        }

        public void Update(HealthInsurance entity)
        {
            _dbContext.HealthInsurances
               .Where(p => p.Id.Equals(entity.Id))
               .ExecuteUpdate(
                setters =>
                setters
                   .SetProperty(p => p.Name, entity.Name)
               );
        }

        public void Remove(Guid id)
        {
            _dbContext.HealthInsurances
               .Where(p => p.Id.Equals(id))
               .ExecuteDelete();
        }

    }
}
