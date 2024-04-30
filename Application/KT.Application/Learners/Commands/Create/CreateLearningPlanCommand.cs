using ErrorOr;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application.Learners.Commands.Create;

public record CreateLearningPlanCommand(
    Guid LearnerId, 
    string Title,
    string Description,
    DateOnly StartDate,
    DateOnly ExpectedEndDate) 
    : IRequest<ErrorOr<LearningPlan>>;

