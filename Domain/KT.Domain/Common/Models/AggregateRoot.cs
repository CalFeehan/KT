namespace KT.Domain.Common.Models;

/// <summary>
///     An aggregate root is a special type of entity that is the root of an aggregate.
///     It is responsible for enforcing the invariants of the aggregate.
/// </summary>
public abstract class AggregateRoot(Guid id) : Entity(id)
{
}