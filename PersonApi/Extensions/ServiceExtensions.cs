using System;
using Contracts.Interfaces;
using Entities.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repo;

namespace PersonApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        public static void ConfigureDapperContext(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }

}
