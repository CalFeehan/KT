﻿using System.Text.Json.Serialization;
using KT.Presentation.API.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KT.Presentation.API;

/// <summary>
///     Dependency injection extension methods.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Add API services.
    /// </summary>
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddOpenApiDocument();
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddLogging();
        services.AddHealthChecks();
        services.AddMemoryCache();
        services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = true)
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        services.AddSingleton<ProblemDetailsFactory, KtProblemDetailsFactory>();

        return services;
    }
}