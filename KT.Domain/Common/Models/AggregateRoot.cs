namespace KT.Domain.Common.Models;

public abstract class AggregateRoot<Guid>(Guid id) : Entity<Guid>(id)
{
}