using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/doctor/procedural-medical")]
    public sealed class ProceduralMedicalController(IProceduralMedicalService service) : ControllerBase
    {
        private readonly IProceduralMedicalService _service = service;

        [HttpPost]
        public async Task<IActionResult> PostAsync(ProceduralMedicalInputModel model)
        {
            return Ok(ResultModel.WithSuccessfully(await _service.AddAsync(model)));
        }

        [HttpPost("add-range")]
        public async Task<IActionResult> PostAsync(List<ProceduralMedicalInputModel> model)
        {
            return Ok(ResultModel.WithSuccessfully(await _service.AddRangeAsync(model)));
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(ResultModel.WithSuccessfully(await _service.GetAsync(id)));
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetByDoctorAsync(Guid doctorId)
        {
            return Ok(ResultModel.WithSuccessfully(await _service.GetByDoctorIdAsync(doctorId)));
        }

        [HttpPut("{id}")]
        public IActionResult PutAsync(Guid id, ProceduralMedicalInputModel model)
        {
            _service.Update(model, id);
            return Ok(ResultModel.WithSuccessfully());
        }
    }
}
