using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Ui.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dev.Middleware.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
    [Authorize]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        private readonly ILogger<ClinicController> _logger;


        public ClinicController(IClinicService clinicService, ILogger<ClinicController> logger)
        {
            _clinicService = clinicService;
            _logger = logger;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        
        public async Task<ActionResult<IEnumerable<ClinicDto>>> GetAllClinicsAsync()
        {

            _logger.LogInformation("GetAllClinicAsync method started");

            try
            {

                var allClinics = await _clinicService.GetAllClinicsAsync();
                if (allClinics == null)
                // return NotFound("No Record Exists");
                {
                    throw new Exception($"No Clinic Found.");
                }

                return Ok(allClinics);
            }
            catch (Exception ex)
            {
                return NotFound(ex);

            }
            finally
            {

            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClinicDto>> AddClinicAsync([FromBody] ClinicDto clinicDto)
        {
            if (clinicDto == null)
                return BadRequest();


            var addClinic = await _clinicService.AddClinicAsync(clinicDto);
            if (addClinic == null)
                return null;


           // return CreatedAtRoute("GetStudentById", new { id=addClinic.ClinicID }, addClinic);

            return Ok(addClinic);
        }



        [HttpGet("{id:int}",Name ="GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClinicDto>> GetClinicByIdAsync(int id)
        {
            //try
            //{

            if (id <= 0)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest("The id must be greater than 0");
            }

                var getClinic = await _clinicService.GetClinicByIdAsync(id);

                if (getClinic == null)
                // return NotFound($"Clinic with {id} not found");
                {
                    _logger.LogError($"Clinic with {id} not found");
                    throw new Exception($"Clinic with {id} not found");
                }


                return Ok(getClinic);
            //}
            //catch (Exception ex)
            //{
            //    //_logger.LogError(ex, "Error fetching Clinic details for ID {id}", id);
            //    return StatusCode(500, "An internal server error occurred.");
            //}


        }

        [HttpGet("{clinicName:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClinicDto>> GetClinicByNameAsync(string clinicName)
        {
            if (string.IsNullOrEmpty(clinicName))
                return BadRequest();

            var getClicnicByName = await _clinicService.GetClinicByNameAsync(clinicName);
            if (getClicnicByName == null)
                return NotFound($"clinic with name {clinicName} not found");

            return Ok(getClicnicByName);

        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteClinicAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be less than or equal to 0");

            var deleteClinic = await _clinicService.DeleteClinicAsync(id);

            if (deleteClinic == false)
                return NotFound($"clinic with {id} not found");

            return Ok(true);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClinicDto>> UpdateClinicAsync(int id, [FromBody] ClinicDto clinicDto)
        {

            if (id <= 0 || clinicDto==null)
            {
                return BadRequest();
            }

            var updateClinic = await _clinicService.UpdateClinicAsync(id, clinicDto);
            if (updateClinic == null)
                return NotFound();



            return Ok(updateClinic);


        }



    }
}
