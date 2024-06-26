﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Services;
using PackIt.Domain.Repositories;
using PackIt.Infrastructure.EF.Contexts;
using PackIt.Infrastructure.EF.Options;
using PackIt.Infrastructure.EF.Repositories;
using PackIt.Infrastructure.EF.Services;
using PackIt.Shared.Options;

namespace PackIt.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddPostrges(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<PostgresOptions>("Postgres");

        services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
        services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

        services.AddDbContext<ReadDbContext>(opt =>
            opt.UseNpgsql(options.ConnectionString));

        services.AddDbContext<WriteDbContext>(opt =>
            opt.UseNpgsql(options.ConnectionString));

        return services;
    }
}
