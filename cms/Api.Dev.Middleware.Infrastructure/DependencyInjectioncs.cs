using Api.Dev.Middleware.Domain.Interfaces;
using Api.Dev.Middleware.Infrastructure.Data;
using Api.Dev.Middleware.Infrastructure.Repositories;
using Api.Dev.Middleware.Infrastructure.Repositories.Auth;
using Api.Dev.Middleware.Infrastructure.Repositories.ClinicRepos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Infrastructure
{
    public static class DependencyInjectioncs
    {

        public static IServiceCollection AddInfrastructureDi(this IServiceCollection services)
        {
            services.AddTransient<IConcurentRepository, ConcurentRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IClinicRepository, ClinicRepository>();
            services.AddTransient<IStaffRepository, StaffReppository>();
          

            return services;

        }
    }
}
