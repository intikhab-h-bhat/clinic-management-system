using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;

namespace Api.Dev.Middleware.Ui.GraphQL.Queries
{

    [ExtendObjectType(Name="Query")]
    public class ClinicQueries
    {

        [GraphQLName("clinics")]
        public async Task<IEnumerable<ClinicDto>> GetClinicsAsync([Service] IClinicService clinicService)
        {
            return await clinicService.GetAllClinicsAsync();
        }

        [GraphQLName("clinicById")]
        public async Task<ClinicDto?> GetClinicByIdAsync(int id, [Service] IClinicService clinicService)
        {
            return await clinicService.GetClinicByIdAsync(id);
        }

        [GraphQLName("clinicByName")]
        public async Task<ClinicDto?> GetClinicByNameAsync(string name, [Service] IClinicService clinicService)
        {
            return await clinicService.GetClinicByNameAsync(name);
        }

      
    }
}
