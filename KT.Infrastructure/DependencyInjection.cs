using KT.Application.Common.Interfaces.Persistence;
using KT.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace KT.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IQualificationRepository, QualificationRepository>();
        
        return services;
    }
}