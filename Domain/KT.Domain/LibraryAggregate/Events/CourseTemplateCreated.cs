using KT.Domain.LibraryAggregate.Entities;

namespace KT.Domain.LibraryAggregate.Events;

public record CourseTemplateCreated(CourseTemplate CourseTemplate) : IDomainEvent;
