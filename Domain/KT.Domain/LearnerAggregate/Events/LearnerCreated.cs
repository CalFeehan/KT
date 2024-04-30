namespace KT.Domain.LearnerAggregate.Events;

public record LearnerCreated(Learner Learner) : IDomainEvent;