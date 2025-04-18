using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;

namespace Api.Dev.Middleware.Ui.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ClinicMutations
    {
        [GraphQLName("addClinic")]
        public async Task<ClinicDto> AddClinicAsync(ClinicDto clinicInput, // your custom input type
            [Service] IClinicService clinicService)
        {
            return await clinicService.AddClinicAsync(clinicInput);
        }

        [GraphQLName("updateClinic")]
        public async Task<ClinicDto> UpdateClinicAsync(int id,ClinicDto clinicInput, // your custom input type
            [Service] IClinicService clinicService)
        {
            return await clinicService.UpdateClinicAsync(id,clinicInput);
        }

        [GraphQLName("deleteClinic")]
        public async Task<bool> DeleteClinicAsync(int id , [Service] IClinicService clinicService)
        {
            return await clinicService.DeleteClinicAsync(id);

        }
    }
}
