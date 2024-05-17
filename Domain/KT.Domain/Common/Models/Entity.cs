namespace KT.Domain.Common.Models;

/// <summary>
///     An entity is an object that is defined by its identity.
///     Entities have a unique identity, which distinguishes them from other entities.
/// </summary>
public abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    ///     The collection of domain events that have been raised by the entity.
    ///     These events will be used to notify other parts of the system about changes to the entity.
    ///     This is the private collection of domain events, so it can only be modified by the entity itself.
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    ///     Creates a new entity with the specified identifier.
    /// </summary>
    protected Entity(Guid id)
    {
        Id = id;
    }

    /// <summary>
    ///     The unique identifier for the entity.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     The public accessor for the domain events.
    ///     This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public bool Equals(Entity? other)
    {
        return Equals((object?)other);
    }

    /// <summary>
    ///     Adds a domain event to the entity.
    /// </summary>
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    ///     Clears the collection of domain events.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity left, Entity right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}