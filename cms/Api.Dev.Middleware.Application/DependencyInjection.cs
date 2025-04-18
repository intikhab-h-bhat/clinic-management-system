using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Application.Services;
using Api.Dev.Middleware.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddApplicationDi(this IServiceCollection services)
        {
            services.AddTransient<IConcurentService, ConcurentService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IStaffService, StaffService>();

            return services;
        }
    }
}
