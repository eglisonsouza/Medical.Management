using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/health-insurance")]
    public sealed class HealthInsuranceController(IHealthInsuranceService service) : ControllerBase
    {
        private readonly IHealthInsuranceService _service = service;

        [HttpPost]
        public async Task<IActionResult> PostAsync(HealthInsuranceInputModel model)
        {
            return Ok(ResultModel.WithSuccessfully((await _service.AddAsync(model))));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(ResultModel.WithSuccessfully(await _service.GetAsync(id)));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ResultModel.WithSuccessfully(_service.GetAll()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, HealthInsuranceInputModel model)
        {
            await _service.UpdateAsync(model, id);
            return Ok(ResultModel.WithSuccessfully());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Remove(id);
            return Ok(ResultModel.WithSuccessfully());
        }
    }
}
