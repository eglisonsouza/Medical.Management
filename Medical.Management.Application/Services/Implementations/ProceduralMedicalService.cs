using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Repositories;

namespace Medical.Management.Application.Services.Implementations
{
    public class ProceduralMedicalService(IProceduralMedicalRepository repository) : IProceduralMedicalService
    {
        private readonly IProceduralMedicalRepository _repository = repository;

        public async Task<ProceduralMedicalViewModel> AddAsync(ProceduralMedicalInputModel model)
        {
            var service = await _repository.AddAsync(model.ToEntity());

            return ProceduralMedicalViewModel.FromEntity(service);
        }

        public async Task<List<ProceduralMedicalViewModel>> AddRangeAsync(List<ProceduralMedicalInputModel> models)
        {
            var entities = models.Select(m => m.ToEntity()).ToList();

            await _repository.AddRangeAsync(entities);

            return entities.Select(ProceduralMedicalViewModel.FromEntity).ToList();
        }

        public async Task<ProceduralMedicalViewModel> GetAsync(Guid id)
        {
            var service = await _repository.GetAsync(id)
                ?? throw new ServiceNotFoundException();

            return ProceduralMedicalViewModel.FromEntity(service);
        }

        public async Task<List<ProceduralMedicalViewModel>> GetByDoctorIdAsync(Guid doctorId)
        {
            var services = await _repository.GetByDoctorIdAsync(doctorId)
                ?? throw new ServiceNotFoundException();

            return services.Select(ProceduralMedicalViewModel.FromEntity).ToList();
        }

        public async Task Update(ProceduralMedicalInputModel model, Guid id)
        {
            var entity = await _repository.GetAsync(id)
                ?? throw new ServiceNotFoundException();

            entity
                .UpdateName(model.Name)
                .UpdateDescription(model.Description)
                .UpdateValue(model.Value)
                .UpdateDurationInMinutes(model.DurationInMinutes);

            _repository.Update(model.ToEntity());
        }
    }
}
