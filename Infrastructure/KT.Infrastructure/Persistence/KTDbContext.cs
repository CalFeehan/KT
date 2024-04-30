using KT.Domain;
using KT.Domain.LearnerAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence;

public class KTDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public DbSet<Learner> Learners { get; set; }

    public KTDbContext(DbContextOptions<KTDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("KT")
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(KTDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}