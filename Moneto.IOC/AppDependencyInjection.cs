using Microsoft.Extensions.DependencyInjection;
using Moneto.Data.Repositories;
using Moneto.Domain.Repositories;
using Moneto.Domain.Repositories.Base;

namespace Moneto.IOC;

public static class AppDependencyInjection
{
    public static void AddAppDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
    }
}