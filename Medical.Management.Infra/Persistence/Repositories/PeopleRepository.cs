using Medical.Management.Domain.Models.Entities;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Medical.Management.Infra.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public abstract class PeopleRepository(SqlServerDbContext dbContext)
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        protected async Task UpdateAsync(People entity)
        {
            await _dbContext.Peoples
                .Where(p => p.Id.Equals(entity.Id))
                .ExecuteUpdateAsync(
                    setters =>
                    setters
                        .SetProperty(p => p.Name, entity.Name)
                        .SetProperty(p => p.LastName, entity.LastName)
                        .SetProperty(p => p.BirthDate, entity.BirthDate)
                        .SetProperty(p => p.Phone, entity.Phone)
                        .SetProperty(p => p.Email, entity.Email)
                        .SetProperty(p => p.Cpf, entity.Cpf)
                        .SetProperty(p => p.BloodType, entity.BloodType)
                    );
        }
    }
}
