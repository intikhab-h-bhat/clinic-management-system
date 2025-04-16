using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dev.Middleware.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet]
        public async Task<ActionResult<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            if (patients == null)
                return NotFound("No record found");


            return Ok(patients);
        }



    }
}
