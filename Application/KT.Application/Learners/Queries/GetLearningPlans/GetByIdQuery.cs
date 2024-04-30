using ErrorOr;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application.Learners.Queries.GetLearningPlans;

public record GetByIdQuery(Guid LearnerId, Guid Id) : IRequest<ErrorOr<LearningPlan>>;
