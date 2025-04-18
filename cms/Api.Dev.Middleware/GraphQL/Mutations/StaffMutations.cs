using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;

namespace Api.Dev.Middleware.Ui.GraphQL.Mutations
{
    [ExtendObjectType(Name ="Mutation")]
    public class StaffMutations
    {
        [GraphQLName("addStaff")]
        public async Task<StaffDto> AddStaffAsync(StaffDto staffInput,
            [Service] IStaffService staffService)
        {

            return await staffService.AddStaffAsync(staffInput);

        }

        [GraphQLName("updateStaff")]
        public async Task<bool> UpdateStaffAsync(int id, StaffDto staffInput,
            [Service] IStaffService staffService)
        {

            return await staffService.UpdateStaffAsync(id, staffInput);
        }

        [GraphQLName("deleteStaff")]
        public async Task<bool> DeleteStaffAsync(int id, [Service] IStaffService staffService)
        {

            return await staffService.DeleteStaffAsync(id);
        }


    }
}
