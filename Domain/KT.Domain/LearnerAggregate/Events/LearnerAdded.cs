using KT.Domain.Common.Models;

namespace KT.Domain.LearnerAggregate.Events;

public record LearnerAdded(Learner Learner) : IDomainEvent;