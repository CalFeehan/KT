using KT.Domain.StudentAggregate;

namespace KT.Domain;

public record StudentCreated(Student Student) : IDomainEvent;