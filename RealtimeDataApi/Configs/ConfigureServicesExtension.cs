using Microsoft.Extensions.DependencyInjection;
using RealtimeDataApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeDataApi.Configs
{
    public static class ConfigureServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("cors", builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });            
            });

            services.AddSignalR();
        }

        public static void ConfigureDependency(this IServiceCollection services)
        {
            services.AddScoped<IReadFromCsvService, ReadFromCsv>();
        }
    }
}
