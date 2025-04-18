using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dev.Middleware.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcurrentController : ControllerBase
    {
        private readonly IConcurentService _concurentService;
        public ConcurrentController(IConcurentService concurentService)
        {
            _concurentService = concurentService;
        }



        [HttpGet("load-all-data")]
        public async Task<IActionResult> LoadAllData()
        {
            var clinicsTask =  _concurentService.GeatAllClinicAsync();
            var staffTask =  _concurentService.GetAllStaffAsync();
            var patientsTask =  _concurentService.GetAllPatientsAsync();

            // Run tasks in parallel
            await Task.WhenAll(clinicsTask, staffTask, patientsTask);

            var result = new
            {
                Clinics =await  clinicsTask,
                Staff = await staffTask,
                Patients = await patientsTask
            };

            return Ok(result);
        }
    }
}
