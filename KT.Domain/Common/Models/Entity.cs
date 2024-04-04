namespace KT.Domain.Common.Models;

public abstract class Entity<Guid> : IEquatable<Entity<Guid>>
{
    public Guid Id { get; protected set; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object obj)
    {
        return obj is Entity<Guid> entity && Id.Equals(entity.Id);
    }

    public bool Equals(Entity<Guid>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<Guid> left, Entity<Guid> right)
    {
        return Equals(right, right);
    }

    public static bool operator !=(Entity<Guid> left, Entity<Guid> right)
    {
        return !Equals(right, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
