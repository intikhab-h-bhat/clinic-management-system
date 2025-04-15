using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Dev.Middleware.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }



        [HttpPost("Register")]
        public  async Task<ActionResult<string>> CreateUserAsync([FromBody] RegisterUserDto register)
        {
            var userCreated = await _authService.RegisterAsync(register);


            return Ok(userCreated);


        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] UserLoginDto user)
        {
            if(user.Email=="" || user.Password == null)
            {
                return BadRequest("Please enter valid email and password");
            }

            var userLogin = await _authService.LoginAsync(user);

            return Ok(userLogin);
         
          
        }

        [HttpGet("logout")]
        public async Task<ActionResult<string>> LogoutAsync()
        {
           var status = await _authService.LogOutAsync();
            return Ok(status);
        }


    }
}
