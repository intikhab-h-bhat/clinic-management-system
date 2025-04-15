using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;

namespace Api.Dev.Middleware.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
            
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {

            var userCred = new UserLogin
            {
                Email = userLoginDto.Email,
                Password = userLoginDto.Password,
            };

            var authUser = await _authRepository.LoginAsync(userCred);

            return authUser;



           
        }
        public async Task<string> LogOutAsync()
        {
            return await _authRepository.LogOutAsync();
        }

        public async Task<string> RegisterAsync(RegisterUserDto registerUserDto)
        {
            var registerUser = new RegisterUser
            {
                FullName = registerUserDto.FullName,
                Email = registerUserDto.Email,
                Password = registerUserDto.Password,
                ClinicId = registerUserDto.ClinicId,
            };

            var userCreated = await _authRepository.RegisterAsync(registerUser);

            return userCreated;

        }
    }
}
