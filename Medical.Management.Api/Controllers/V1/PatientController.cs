using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Management.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/people/patient")]
    public class PatientController(IPatientService service) : ControllerBase
    {
        private readonly IPatientService _service = service;

        [HttpPost]
        public async Task<IActionResult> PostAsync(PatientInputModel model)
        {
            return Ok(await _service.AddAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _service.GetAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, PatientInputModel model)
        {
            await _service.UpdateAsync(model, id);
            return NoContent();
        }
    }
}
