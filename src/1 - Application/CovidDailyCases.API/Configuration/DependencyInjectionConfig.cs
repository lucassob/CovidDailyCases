using CovidDailyCases.Domain.Interfaces;
using CovidDailyCases.Infrastructure.Data.Context;
using CovidDailyCases.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace CovidDailyCases.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<CovidCasesDbContext>();
        services.AddScoped<ICovidCasesRepository, CovidCasesRepository>();

        return services;
    }
}
