using Microsoft.Extensions.DependencyInjection;
using Moneto.Domain.Settings;

namespace Moneto.IOC;

public static class AppSettingsDependencyInjection
{
    public static void AddAppSettings(this IServiceCollection services, AppSettings appSettings)
    {
        if(appSettings == null)
        {
            throw new ArgumentNullException(nameof(appSettings));
        }
        
        services.AddSingleton(appSettings);
    }
}