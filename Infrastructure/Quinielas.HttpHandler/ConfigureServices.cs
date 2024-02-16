using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Quinielas.HttpHandler
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IHttpGetRepository, HttpGetRepository>();

            return services;
        }
    }
}