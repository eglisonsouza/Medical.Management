using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Service;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Medical.Management.Application.Services
{
    public class HealthInsuranceService(SqlServerDbContext dbContext) : IHealthInsuranceService
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<HealthInsuranceViewModel> AddAsync(HealthInsuranceInputModel model)
        {
            var healthInsurance = await _dbContext.HealthInsurances.AddAsync(model.ToEntity());

            await _dbContext.SaveChangesAsync();

            return HealthInsuranceViewModel.FromEntity(healthInsurance.Entity);
        }

        public async Task<HealthInsuranceViewModel> GetAsync(Guid id)
        {
            var healthInsurance = await _dbContext.HealthInsurances.SingleOrDefaultAsync(d => d.Id.Equals(id))
                ?? throw new HealthInsuranceNotFoundException();

            return HealthInsuranceViewModel.FromEntity(healthInsurance);
        }

        public List<HealthInsuranceViewModel> GetAll()
        {
            return _dbContext.HealthInsurances.Select(HealthInsuranceViewModel.FromEntity).ToList();
        }

        public void Update(HealthInsuranceInputModel model, Guid id)
        {
            _dbContext.HealthInsurances
               .Where(p => p.Id.Equals(id))
               .ExecuteUpdate(
                setters =>
                setters
                   .SetProperty(p => p.Name, model.Name)
               );
        }

        public void Remove(Guid id)
        {
            _dbContext.HealthInsurances
               .Where(p => p.Id.Equals(id))
               .ExecuteDeleteAsync();
        }
    }
}
