using Api.Dev.Middleware.Application;
using Api.Dev.Middleware.Infrastructure;
using Api.Dev.Middleware.Ui.GraphQL.Mutations;
using Api.Dev.Middleware.Ui.GraphQL.Queries;

namespace Api.Dev.Middleware.Ui.ExtensionMethods
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            services.AddInfrastructureDi();
            services.AddApplicationDi();

            services
    .AddGraphQLServer()
    //.AddQueryType<Query>()
    //.AddType<ClinicType>()
    //.AddType<StaffType>()   
    .AddQueryType(d => d.Name("Query"))
    .AddType<ClinicQueries>()// Register the class that extends the query
    .AddType<StaffQueries>()
   .AddMutationType(d => d.Name("Mutation"))
    .AddType<ClinicMutations>(); // Add this line
            //.AddAuthorization();

            return services;

        }

    }
}
