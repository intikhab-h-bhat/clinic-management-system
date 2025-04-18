using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Dev.Middleware.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IClinicService _clinicService;
        private readonly IStaffService _staffService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
            
        }



        [HttpPost]
        public async Task<ActionResult<PatientDto>> AddPatientAsync([FromBody] PatientDto patient)
        {
            if (patient == null)
                return BadRequest();

            var addPatient = await _patientService.AddPatientAsync(patient);
            if (addPatient == null)
                return null;



            return Ok(addPatient);
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
