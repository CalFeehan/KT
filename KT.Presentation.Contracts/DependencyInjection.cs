using Microsoft.Extensions.DependencyInjection;

namespace KT.Presentation.Contracts;

public static class DependencyInjection
{
    public static IServiceCollection AddContracts(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        
        return services;
    }
}