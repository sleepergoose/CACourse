using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Services;
using PackIt.Infrastructure.EF;
using PackIt.Infrastructure.Services;
using PackIt.Shared.Extensions;

namespace PackIt.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostrges(configuration);
        services.AddQueries();

        services.AddSingleton<IWeatherService, DumbWeatherService>();

        return services;
    }
}
