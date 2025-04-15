using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dev.Middleware.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;
        private readonly ILogger<StaffController> _logger;
        public StaffController(IStaffService staffService,ILogger<StaffController> logger)
        {
            _staffService = staffService;
            _logger = logger;
            
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StaffDto>> AddStaffAsync([FromBody] StaffDto staffDto)
        {
            try
            {

                if (staffDto==null)
                {
                    _logger.LogWarning("There is no Data to Add");

                    return BadRequest("There is no data to be added");
                }


                var addStaff = await _staffService.AddStaffAsync(staffDto);


                if(addStaff==null)
                {
                    _logger.LogError("staff not saved");
                }


                return Ok(addStaff);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;

            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetStaffDto>>> GetAllStaffAsync()
        {
            var allStaff = await _staffService.GetAllStaffAsync();
            if (allStaff == null)
                return NotFound("No record exist");

            return Ok(allStaff);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StaffDto>> GetStaffByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id should be greater than 0");
            }

            var getStaff = await _staffService.GetStaffByIdAsync(id);

            if (getStaff == null)
                return NotFound("No Record exist");

            return Ok(getStaff);



        }

        [HttpGet("{staffName:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StaffDto>> GetStaffByNameAsync(string staffName)
        {
            if (string.IsNullOrEmpty(staffName))
                return BadRequest();
            var getStaffByName = await _staffService.GetStaffByNameAsync(staffName);

            if (getStaffByName == null)
                return NotFound($"The staff with name {staffName} not found");

            return Ok(getStaffByName);

        }

       
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteStaffAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var deleteStaff = await _staffService.DeleteStaffAsync(id);
            if (!deleteStaff)
                return NotFound();

            return Ok(deleteStaff);

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateStaffAsync(int id, [FromBody] StaffDto staffDto)
        {
            if (id <= 0 || staffDto==null)
                return BadRequest();

                var updateStaff = await _staffService.UpdateStaffAsync(id, staffDto);

            if (!updateStaff)
                return NotFound();

            return Ok(updateStaff);            


        }   


    }
}
