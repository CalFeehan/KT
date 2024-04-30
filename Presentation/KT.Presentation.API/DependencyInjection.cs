using KT.Presentation.API.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KT.Presentation.API;

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
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        services.AddSingleton<ProblemDetailsFactory, KTProblemDetailsFactory>();

        return services;
    }
}
