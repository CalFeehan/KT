using KT.Domain.Common.Models;
using KT.Domain.CourseAggregate;
using KT.Domain.CourseTemplateAggregate;
using KT.Domain.CourseTemplateAggregate.Entities;
using KT.Domain.CourseTemplateAggregate.ValueObjects;
using KT.Domain.LearnerAggregate;
using KT.Domain.ModuleTemplateAggregate;
using KT.Domain.SessionAggregate;
using KT.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence;

public class KtDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public KtDbContext(DbContextOptions<KtDbContext> options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Learner> Learners { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<CourseTemplate> CourseTemplates { get; set; }

    public DbSet<CourseTemplateModuleTemplate> CourseTemplateModuleTemplates { get; set; }

    public DbSet<ModuleTemplate> ModuleTemplates { get; set; }

    public DbSet<Session> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("KT")
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(KtDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}