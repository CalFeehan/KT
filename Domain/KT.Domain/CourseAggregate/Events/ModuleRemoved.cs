using KT.Domain.CourseAggregate.Entities;

namespace KT.Domain.CourseAggregate.Events;

public record ModuleRemoved(Guid CourseId, Module Module) : IDomainEvent;
