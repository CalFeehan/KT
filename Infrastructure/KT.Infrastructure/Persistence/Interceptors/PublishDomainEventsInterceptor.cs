using KT.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KT.Infrastructure.Persistence.Interceptors;

/// <summary>
///     An interceptor that publishes domain events when saving changes to the database.
///     This will ensure that all subsequent actions are also part of the same transaction.
/// </summary>
public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    /// <summary>
    ///     The publisher used to publish domain events.
    /// </summary>
    private readonly IPublisher _publisher;

    public PublishDomainEventsInterceptor(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        throw new NotImplementedException();
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    /// <summary>
    ///     Publishes the domain events for the entities that have them, and clears the domain events.
    /// </summary>
    private async Task PublishDomainEvents(DbContext? context)
    {
        var entitiesWithDomainEvents = context?.ChangeTracker.Entries<Entity>()
                                           .Select(e => e.Entity)
                                           .Where(e => e.DomainEvents.Count is not 0)
                                           .ToList()
                                       ?? [];

        foreach (var entity in entitiesWithDomainEvents)
        {
            var domainEvents = entity.DomainEvents.ToArray();

            entity.ClearDomainEvents();

            foreach (var domainEvent in domainEvents) await _publisher.Publish(domainEvent);
        }
    }
}