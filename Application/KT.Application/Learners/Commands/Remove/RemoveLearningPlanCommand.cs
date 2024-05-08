using ErrorOr;
using MediatR;

namespace KT.Application.Learners.Commands.Remove;

public record RemoveLearningPlanCommand(Guid LearnerId, Guid Id) : IRequest<ErrorOr<Task>>;