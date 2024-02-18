using Quinielas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quinielas.Application.Interface.Persistence;
using Quinielas.Persistence.Interceptors;
using Quinielas.Persistence.Repositories;
using Quinielas.HttpHandler;

namespace Quinielas.Persistence;
public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("QuinielasConnection"),
                    builder =>
                        builder.MigrationsAssembly(
                            typeof(ApplicationDbContext).Assembly.FullName
                        )
                )
        );

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IIndiceCatalogoRepository, IndiceCatalogoRepository>();
        services.AddScoped<IContenidoCatalogoRepository, ContenidoCatalogoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IHttpGetRepository, HttpGetRepository>();
        services.AddScoped<IRequestConfigurationStrategy, ApiSportConfiguration>();
        return services;
    }
}
