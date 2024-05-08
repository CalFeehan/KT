using KT.Domain.CourseAggregate;

namespace KT.Domain.CourseAggregate.Events;

public record CourseAdded(Course Course) : IDomainEvent;