using Medical.Management.Application.Models.InputModels;
using Medical.Management.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Management.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/doctor/service")]
    public sealed class ServiceController(IProceduralMedicalService service) : ControllerBase
    {
        private readonly IProceduralMedicalService _service = service;

        [HttpPost]
        public async Task<IActionResult> PostAsync(ProceduralMedicalInputModel model)
        {
            return Ok(await _service.AddAsync(model));
        }

        [HttpPost("add-range")]
        public async Task<IActionResult> PostAsync(List<ProceduralMedicalInputModel> model)
        {
            return Ok(await _service.AddRangeAsync(model));
        }

        [HttpGet("id/procedural-medical/{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _service.GetAsync(id));
        }

        [HttpGet("id/doctor/{doctorId}")]
        public async Task<IActionResult> GetByDoctorAsync(Guid doctorId)
        {
            return Ok(await _service.GetByDoctorIdAsync(doctorId));
        }

        [HttpPut("{id}")]
        public IActionResult PutAsync(Guid id, ProceduralMedicalInputModel model)
        {
            _service.Update(model, id);
            return NoContent();
        }
    }
}
