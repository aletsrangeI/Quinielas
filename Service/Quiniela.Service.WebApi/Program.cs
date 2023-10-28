using Quiniela.Service.WebApi.Modules.Feature;
using Quinielas.Persistence;
using Quinielas.Application.UseCases;
using Quiniela.Service.WebApi.Modules.Authentication;
using Quiniela.Service.WebApi.Modules.Injection;
using Quiniela.Service.WebApi.Modules.Swagger;
using Quiniela.Service.WebApi.Modules.HealthCheck;
using Quiniela.Service.WebApi.Modules.Watch;
using Quiniela.Service.WebApi.Modules.RateLimiter;
using HealthChecks.UI.Client;
using WatchDog;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDog(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quiniela.Service.WebApi");
        }); //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    });
}

app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks(
    "/health",
    new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }
);

app.UseWatchDog(conf => {
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});

app.Run();

public partial class Program { };