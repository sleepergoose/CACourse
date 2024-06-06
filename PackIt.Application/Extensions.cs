﻿    using Microsoft.Extensions.DependencyInjection;
using PackIt.Domain.Factories;
using PackIt.Domain.Policies;
using PackIt.Shared.Extensions;

namespace PackIt.Application;

public static class Extensions
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IPackingListFactory, PackingListFactory>();

        services.Scan(b => b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<IPackingItemsPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}
