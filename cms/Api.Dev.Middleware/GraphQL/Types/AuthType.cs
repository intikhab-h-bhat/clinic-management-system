using Api.Dev.Middleware.Application.Dtos;

namespace Api.Dev.Middleware.Ui.GraphQL.Types
{
    public class AuthType:ObjectType<UserLoginDto>
    {

        protected override void Configure(IObjectTypeDescriptor<UserLoginDto> descriptor)
        {
            descriptor.Field(u => u.Email).Description("user email");
            descriptor.Field(u => u.Password).Description("user password");
          
        }

    }
}
