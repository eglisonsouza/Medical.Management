using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Service;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Medical.Management.Application.Services
{
    public class ServiceDoctorService(SqlServerDbContext dbContext) : IServiceDoctorService
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<ServiceDoctorViewModel> AddAsync(ServiceDoctorInputModel model)
        {
            var service = await _dbContext.Services.AddAsync(model.ToEntity());
            await _dbContext.SaveChangesAsync();

            return ServiceDoctorViewModel.FromEntity(service.Entity);
        }

        public async Task<List<ServiceDoctorViewModel>> AddRangeAsync(List<ServiceDoctorInputModel> models)
        {
            var entities = models.Select(m => m.ToEntity()).ToList();

            await _dbContext.Services.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

            return entities.Select(ServiceDoctorViewModel.FromEntity).ToList();
        }

        public async Task<ServiceDoctorViewModel> GetAsync(Guid id)
        {
            var service = await _dbContext.Services.SingleOrDefaultAsync(d => d.Id.Equals(id))
                ?? throw new ServiceNotFoundException();

            return ServiceDoctorViewModel.FromEntity(service);
        }

        public async Task<List<ServiceDoctorViewModel>> GetByDoctorIdAsync(Guid doctorId)
        {
            var services = await _dbContext.Services.Where(s => s.DoctorId.Equals(doctorId)).ToListAsync()
                ?? throw new ServiceNotFoundException();

            return services.Select(ServiceDoctorViewModel.FromEntity).ToList();
        }

        public void Update(ServiceDoctorInputModel model, Guid id)
        {
            _dbContext.Services
               .Where(p => p.Id.Equals(id))
               .ExecuteUpdate(
                setters =>
                setters
                   .SetProperty(p => p.Name, model.Name)
                   .SetProperty(p => p.Description, model.Description)
                   .SetProperty(p => p.Value, model.Value)
                   .SetProperty(p => p.DurationInMinutes, model.DurationInMinutes)
               );
        }
    }
}
