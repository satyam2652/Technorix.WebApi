using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Application.Helpers;
using Technorix.Application.Interfaces;
using Technorix.Infrastructure.Repository;
using Technorix.Infrastructure.Service;

namespace Technorix.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IJobsService, JobsService>();
            services.AddTransient<IJobsRepo, JobsRepo>();
            services.AddTransient<IDepartmentsService, DepartmentService>();
            services.AddTransient<IDepartmentsRepo, DepartmentsRepo>();

            services.AddScoped<Common>();

        }
    }
}
