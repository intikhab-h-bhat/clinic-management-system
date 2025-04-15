using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Domain.Interfaces
{
   public interface IAuthRepository
    {

        Task<string> RegisterAsync(RegisterUser registerUser);
        Task<string> LoginAsync(UserLogin userLogin);
        Task<string> LogOutAsync();

    }
}
