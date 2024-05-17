using KT.Domain.Common.Models;
using KT.Domain.LearnerAggregate.Entities;

namespace KT.Domain.LearnerAggregate.Events;

public record LearningPlanAdded(Guid LearnerId, LearningPlan LearningPlan) : IDomainEvent;