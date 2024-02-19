

using System.Text.Json.Serialization;

namespace Quiniela.Service.WebApi.Modules.Feature;
public static class FeatureExtensions
{
    public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
    {
        string myPolicy = "policyQuinielas";

        services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                                    .AllowAnyHeader()
                                                                                    .AllowAnyMethod()));
        services.AddMvc();
        services.AddControllers().AddJsonOptions(options =>
        {
            var enumConverter = new JsonStringEnumConverter();
            options.JsonSerializerOptions.Converters.Add(enumConverter);
        });

        return services;
    }
}
