namespace KT.Domain.LearnerAggregate.Events;

public record LearnerAdded(Learner Learner) : IDomainEvent;