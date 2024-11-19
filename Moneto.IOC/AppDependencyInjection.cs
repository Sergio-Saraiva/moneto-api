using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moneto.Data.Repositories;
using Moneto.Domain.Repositories;
using Moneto.Domain.Services;

namespace Moneto.IOC;

public static class AppDependencyInjection
{
    public static void AddAppDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUserService, UserService>();
    }
}