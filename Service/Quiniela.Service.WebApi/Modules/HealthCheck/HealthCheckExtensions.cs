namespace Quiniela.Service.WebApi.Modules.HealthCheck;
public static class HealthCheckExtensions
{
    public static IServiceCollection AddHealthCheck(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddHealthChecks()
            .AddSqlServer(
                configuration.GetConnectionString("QuinielasConnection"),
                tags: new[] { "db", "sql", "sqlserver" }
            )
            .AddCheck<HealthCheckCustom>(
                "HealthCheckCustom",
                failureStatus: null,
                tags: new[] { "custom" }
            );
        services.AddHealthChecksUI().AddInMemoryStorage();
        return services;
    }
}