using KT.Domain.LearnerAggregate;

namespace KT.Domain;

public record LearnerCreated(Learner Learner) : IDomainEvent;