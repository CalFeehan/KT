using KT.Domain.CourseAggregate;

namespace KT.Domain;

public record CourseCreated(Course Course) : IDomainEvent;