using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;



namespace Quiniela.Service.WebApi.Modules.Swagger;
public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Empresa.Ecommerce.Services.WebApi",
                    Description = "Curso Arquitectura de aplicaciones .net",
                    TermsOfService = new Uri("https://twitter.com/aletsrangel"),
                    Contact = new OpenApiContact
                    {
                        Name = "Alejandro Rangel",
                        Email = "alejandro.rangel.avl@gmail.com",
                        Url = new Uri("https://twitter.com/aletsrangel"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                }
            );
            //set the comments path for the swagger json and ui

            var xmlFile =
                $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { securityScheme, new List<string> { } }
            });
        });

        return services;
    }
}
