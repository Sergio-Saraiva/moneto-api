using Microsoft.Extensions.DependencyInjection;
using Moneto.Domain.Settings;

namespace Moneto.IOC;

public static class CorsDependencyInjection
{
    public static void AddDevCors(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("DevCorsPolicy",
                builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials());
        });
    }

    public static void AddProdCors(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("ProdCorsPolicy",
                builder => builder
                    .WithMethods(appSettings.CORS.AllowedMethods)
                    .WithOrigins(appSettings.CORS.AllowedOrigins)
                    .WithHeaders(appSettings.CORS.AllowedHeaders)
                    .AllowCredentials());
        });
    }
}