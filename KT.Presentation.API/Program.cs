using KT.Application;
using KT.Infrastructure;
using KT.Presentation.API.Common.Errors;
using KT.Presentation.API.Middleware;
using KT.Presentation.Contracts;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApi()
        .AddContracts()
        .AddApplication()
        .AddInfrastructure();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.Run();
}

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddLogging();
        services.AddHealthChecks();
        services.AddMemoryCache();
        services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddSingleton<ProblemDetailsFactory, KTProblemDetailsFactory>();

        return services;
    }
}
