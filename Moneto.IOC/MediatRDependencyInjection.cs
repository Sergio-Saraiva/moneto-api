using Microsoft.Extensions.DependencyInjection;

namespace Moneto.IOC;

public static class MediatRDependencyInjection {
    public static void AddAppMediatR(this IServiceCollection services) {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Moneto.Application"));
        });
    }
}