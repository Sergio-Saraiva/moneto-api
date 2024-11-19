using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moneto.Data.Context;
using Moneto.Domain.Settings;

namespace Moneto.IOC;

public static class PostgresDependencyInjection {
    public static void AddPostgres(this IServiceCollection services, AppSettings appSettings) {
        services.AddDbContext<MonetoDbContext>(options => {
            options.UseNpgsql(appSettings.ConnectionStrings.DefaultConnection);
        });
    }
}