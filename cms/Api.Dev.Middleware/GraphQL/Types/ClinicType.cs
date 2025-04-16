using Api.Dev.Middleware.Application.Dtos.ClinicDto;

namespace Api.Dev.Middleware.Ui.GraphQL.Types
{
    public class ClinicType:ObjectType<ClinicDto>
    {

        protected override void Configure(IObjectTypeDescriptor<ClinicDto> descriptor)
        {
            descriptor.Field(c => c.ClinicID).Description("Clinic Identifier");
            descriptor.Field(c => c.ClinicName).Description("Clinic Name");            
            //descriptor.Field(c => c.Staffs).Type<ListType<StaffType>>().Description("List of staff members in the clinic");
        }

    }
}
