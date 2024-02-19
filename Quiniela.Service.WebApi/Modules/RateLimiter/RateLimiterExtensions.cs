using Microsoft.AspNetCore.RateLimiting;

namespace Quiniela.Service.WebApi.Modules.RateLimiter;
public static class RateLimiterExtensions
{
    public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        string fixedWindowPolicy = "fixedWindow";
        services.AddRateLimiter(configureOptions =>
        {
            configureOptions.AddFixedWindowLimiter(policyName: fixedWindowPolicy, fixedWindow =>
            {
                fixedWindow.PermitLimit = int.Parse(configuration["RateLimiting:PermitLimit"]);
                fixedWindow.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimiting:Window"]));
                fixedWindow.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                fixedWindow.QueueLimit = int.Parse(configuration["RateLimiting:QueueLimit"]);
            });
            configureOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        });
        return services;
    }
}