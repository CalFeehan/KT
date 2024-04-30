using ErrorOr;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application.Learners.Queries.GetLearningPlans;

public record ListQuery(Guid LearnerId) : IRequest<ErrorOr<IList<LearningPlan>>>;