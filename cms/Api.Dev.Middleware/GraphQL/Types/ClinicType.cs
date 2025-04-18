using Api.Dev.Middleware.Application.Dtos.ClinicDto;

namespace Api.Dev.Middleware.Ui.GraphQL.Types
{
    public class ClinicType:ObjectType<ClinicDto>
    {

        protected override void Configure(IObjectTypeDescriptor<ClinicDto> descriptor)
        {
            descriptor.Field(c => c.ClinicID).Description("Clinic Identifier");
            descriptor.Field(c => c.ClinicName).Description("Clinic Name");
            descriptor.Field(c => c.Address).Description("Clinic Address");
            descriptor.Field(c => c.ContactNumber).Description("Contact Number");
            descriptor.Field(c => c.Website).Description("Clinic website address");
           
        }

    }
}
