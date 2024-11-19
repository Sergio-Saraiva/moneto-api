using Microsoft.Extensions.DependencyInjection;
using Moneto.Application.AutoMapper;

namespace Moneto.IOC;

public static class AutoMapperDependencyInjection
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
    }
}