using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Extensions;

namespace PackIt.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddQueries();

        return services;
    }
}
