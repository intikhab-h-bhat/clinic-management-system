using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dev.Middleware.Ui.GraphQL.Queries
{
    [ExtendObjectType(Name="Query")]
    public class AuthQueries
    {

        [GraphQLName("Login")]
        public async Task<string> Login( [FromBody] UserLoginDto userLoginDto ,[Service] IAuthService authService)
        {
            return await authService.LoginAsync(userLoginDto);
        }
    }
}
