using Core.TavridaTask.Interfaces.Repositories;
using Infrastructure.TavridaTask.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.TavridaTask;

public static class InfrastructureModule
{
    public static IServiceCollection RegisterInfrastructureModuleDependencies(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}