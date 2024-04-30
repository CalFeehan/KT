using KT.Domain.LearnerAggregate.Entities;

namespace KT.Domain.LearnerAggregate.Events;

public record LearningPlanRemoved(Guid LearnerId, LearningPlan LearningPlan) : IDomainEvent;