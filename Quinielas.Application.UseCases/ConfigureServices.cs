using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Quinielas.Application.Interface.UseCases;
using Quinielas.Application.UseCases.ContenidoCatalogos;
using Quinielas.Application.UseCases.IndiceCatalogos;
using Quinielas.Application.UseCases.Users;
using Quinielas.Application.Validator;

namespace Quinielas.Application.UseCases

{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IIndiceCatalogoApplication, IndiceCatalogosApplication>();
            services.AddScoped<IContenidoCatalogoApplication, ContenidoCatalogoApplication>();

            services.AddTransient<UsersDTOValidator>();
            services.AddTransient<IndiceCatalogoDTOValidator>();
            services.AddTransient<ContenidoCatalogoDTOValidator>();

            return services;
        }
    }
}

