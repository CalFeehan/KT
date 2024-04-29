namespace KT.Domain.Common.Models;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(Guid id)
    {
        Id = id;
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && Id.Equals(entity.Id);
    }

    public bool Equals(Entity? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity left, Entity right)
    {
        return Equals(right, right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !Equals(right, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
