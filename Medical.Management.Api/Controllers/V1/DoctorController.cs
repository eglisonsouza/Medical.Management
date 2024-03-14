using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Management.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/people/doctor")]
    public class DoctorController(IDoctorService service) : ControllerBase
    {
        private readonly IDoctorService _service = service;

        [HttpPost]
        public async Task<IActionResult> PostAsync(DoctorInputModel model)
        {
            return Ok(await _service.AddAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _service.GetAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, DoctorInputModel model)
        {
            await _service.UpdateAsync(model, id);
            return NoContent();
        }
    }
}
