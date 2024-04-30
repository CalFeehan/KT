using KT.Domain.LearnerAggregate.Entities;

namespace KT.Domain.LearnerAggregate.Events;

public record LearningPlanCreated(Guid LearnerId, LearningPlan LearningPlan) : IDomainEvent;
