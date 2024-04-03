using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Management.Infra.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public sealed class PatientRepository(SqlServerDbContext dbContext) : PeopleRepository(dbContext), IPatientRepository
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<Patient> AddAsync(Patient entity)
        {
            var result = await _dbContext.Patients.AddAsync(entity);

            return result.Entity;
        }

        public async Task<Patient?> GetAsync(Guid id)
        {
            return await _dbContext.Patients.Include(d => d.People).SingleOrDefaultAsync(d => d.Id.Equals(id));
        }

        public async Task UpdateAsync(Patient entity)
        {
            await
                _dbContext.Patients
                .Where(d => d.Id.Equals(entity.Id))
                .ExecuteUpdateAsync(
                    setters =>
                    setters
                        .SetProperty(p => p.Height, entity.Height)
                        .SetProperty(p => p.Weight, entity.Weight)
                );

            await UpdateAsync(entity.People);
        }

        public Task SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
