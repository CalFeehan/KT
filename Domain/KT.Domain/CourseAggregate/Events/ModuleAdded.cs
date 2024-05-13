using KT.Domain.Common.Models;
using KT.Domain.CourseAggregate.Entities;

namespace KT.Domain.CourseAggregate.Events;

public record ModuleAdded(Guid CourseId, Module Module) : IDomainEvent;
