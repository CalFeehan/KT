using FluentValidation;
using KT.Application.Common.Behaviours;
using KT.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KT.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}