using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;

namespace Api.Dev.Middleware.Ui.GraphQL.Queries
{

    [ExtendObjectType(Name = "Query")]
    public class StaffQueries
    {
        [GraphQLName("staff")]
        public async Task<IEnumerable<GetStaffDto>> GetStaffAsync([Service] IStaffService staffService)
        {
            return await staffService.GetAllStaffAsync();
        }
        [GraphQLName("staffById")]
        public async Task<StaffDto?> GetStaffByIdAsync(int id, [Service] IStaffService staffService)
        {
            return await staffService.GetStaffByIdAsync(id);
        }

        [GraphQLName("clinicByName")]
        public async Task<StaffDto> GetStaffByNameAsync(string name, [Service] IStaffService staffService)
        {
            return await staffService.GetStaffByNameAsync(name);
        }

    }
}
