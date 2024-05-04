using AutoMapper;
using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Interfaces;
using Medical.Management.Domain.Repositories;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Application.Services.Implementations
{
    public class HealthInsuranceService(IHealthInsuranceRepository repository, IMapper mapper, ResultModel resultModel) : IHealthInsuranceService
    {
        private readonly IHealthInsuranceRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly ResultModel _resultModel = resultModel;

        public async Task<ResultModel> AddAsync(HealthInsuranceInputModel model)
        {
            var healthInsurance = await _repository.AddAsync(model.ToEntity());

            _resultModel.AddResult(_mapper.Map<HealthInsuranceViewModel>(healthInsurance));

            return _resultModel;
        }

        public async Task<ResultModel> GetAsync(Guid id)
        {
            var healthInsurance = await _repository.GetAsync(id)
                ?? throw new HealthInsuranceNotFoundException();

            _resultModel.AddResult(_mapper.Map<HealthInsuranceViewModel>(healthInsurance));

            return _resultModel;
        }

        public ResultModel GetAll()
        {
            var list = _repository.GetAll().Select(HealthInsuranceViewModel.FromEntity).ToList();

            _resultModel.AddResult(list);

            return _resultModel;
        }

        public async Task UpdateAsync(HealthInsuranceInputModel model, Guid id)
        {
            var healthInsurance = await _repository.GetAsync(id)
                ?? throw new HealthInsuranceNotFoundException();

            healthInsurance.UpdateName(model.Name);

            _repository.Update(healthInsurance);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
