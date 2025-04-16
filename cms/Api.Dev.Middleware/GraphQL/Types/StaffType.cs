using Api.Dev.Middleware.Domain.Entities;

namespace Api.Dev.Middleware.Ui.GraphQL.Types
{
    public class StaffType:ObjectType<Staff>
    {
        protected override void Configure(IObjectTypeDescriptor<Staff> descriptor)
        {
            descriptor.Field(s => s.StaffID);
            descriptor.Field(s => s.StaffName);
            descriptor.Field(s => s.Email);
            descriptor.Field(s => s.Clinic).Type<ListType<ClinicType>>().Description("List of staff members in the clinic");
        }
    }
}
