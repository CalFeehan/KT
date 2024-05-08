using ErrorOr;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application.Learners.Commands.Add;

public record AddLearningPlanCommand(
    Guid LearnerId, 
    string Title,
    string Description) 
    : IRequest<ErrorOr<LearningPlan>>;

