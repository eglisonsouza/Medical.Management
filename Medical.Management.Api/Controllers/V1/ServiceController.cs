using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Management.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/doctor/service")]
    public class ServiceController(IServiceDoctorService service) : ControllerBase
    {
        private readonly IServiceDoctorService _service = service;

        [HttpPost]
        public async Task<IActionResult> PostAsync(ServiceDoctorInputModel model)
        {
            return Ok(await _service.AddAsync(model));
        }

        [HttpPost("add-range")]
        public async Task<IActionResult> PostAsync(List<ServiceDoctorInputModel> model)
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
        public IActionResult PutAsync(Guid id, ServiceDoctorInputModel model)
        {
            _service.Update(model, id);
            return NoContent();
        }
    }
}
