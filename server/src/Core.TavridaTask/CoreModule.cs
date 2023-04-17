using Core.TavridaTask.Interfaces.Services;
using Core.TavridaTask.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.TavridaTask;

public static class CoreModule
{
    public static IServiceCollection RegisterCoreModuleDependencies(
        this IServiceCollection services)
    {
        services.AddScoped<ICompanyBranchService, CompanyBranchService>();

        return services;
    }
}