using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Management.Infra.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public sealed class DoctorRepository(SqlServerDbContext dbContext) : PeopleRepository(dbContext), IDoctorRepository
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<Doctor> AddAsync(Doctor entity)
        {
            var result = await _dbContext.Doctors.AddAsync(entity);

            await SaveAsync();

            return result.Entity;
        }

        public Task<Doctor?> GetAsync(Guid id)
        {
            return _dbContext.Doctors.Include(d => d.People).SingleOrDefaultAsync(d => d.Id.Equals(id));
        }

        public async Task UpdateAsync(Doctor entity)
        {
            await _dbContext.Doctors
                .Where(d => d.Id.Equals(entity.Id))
                .ExecuteUpdateAsync(
                    setters =>
                    setters
                        .SetProperty(p => p.CrmRegistration, entity.CrmRegistration)
                        .SetProperty(p => p.Specialty, entity.Specialty)
                );

            await UpdateAsync(entity.People);
        }

        public bool CpfIsExist(string cpf)
        {
            return _dbContext.Peoples.Any(x => x.Cpf.Equals(cpf));
        }

        public Task SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
