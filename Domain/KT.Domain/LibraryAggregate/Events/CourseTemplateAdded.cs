using KT.Domain.LibraryAggregate.Entities;

namespace KT.Domain.LibraryAggregate.Events;

public record CourseTemplateAdded(CourseTemplate CourseTemplate) : IDomainEvent;
