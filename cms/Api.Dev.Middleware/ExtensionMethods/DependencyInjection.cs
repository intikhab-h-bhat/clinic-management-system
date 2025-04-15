using Api.Dev.Middleware.Application;
using Api.Dev.Middleware.Infrastructure;

namespace Api.Dev.Middleware.Ui.ExtensionMethods
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {


            services.AddInfrastructureDi();
            services.AddApplicationDi();


            return services;

        }

    }
}
