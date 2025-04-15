using Api.Dev.Middleware.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto registerUserDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
        Task<string> LogOutAsync();
    }
}
