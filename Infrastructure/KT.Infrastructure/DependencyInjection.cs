

using KT.Application.Common.Interfaces.Persistence;
using KT.Infrastructure.Persistence;
using KT.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KT.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<KTDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=KT;User Id=sa;Password=Sa30176864!;TrustServerCertificate=True;");
        });

        services.AddScoped<PublishDomainEventsInterceptor>();
        
        services.AddScoped<ILearnerRepository, LearnerRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseTemplateRepository, CourseTemplateRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();

        return services;
    }
}