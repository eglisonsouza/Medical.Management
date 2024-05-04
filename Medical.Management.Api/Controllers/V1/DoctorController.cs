using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/people/doctor")]
    public sealed class DoctorController(IDoctorService service) : ControllerBase
    {
        private readonly IDoctorService _service = service;

        [HttpPost]
        public async Task<IActionResult> PostAsync(DoctorInputModel model)
        {
            return Ok(ResultModel.WithSuccessfully((await _service.AddAsync(model))!));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(ResultModel.WithSuccessfully((await _service.GetAsync(id))!));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, DoctorInputModel model)
        {
            await _service.UpdateAsync(model, id);
            return Ok(ResultModel.WithSuccessfully());
        }
    }
}
