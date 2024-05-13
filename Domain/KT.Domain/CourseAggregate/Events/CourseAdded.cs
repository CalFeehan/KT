using KT.Domain.Common.Models;

namespace KT.Domain.CourseAggregate.Events;

public record CourseAdded(Course Course) : IDomainEvent;