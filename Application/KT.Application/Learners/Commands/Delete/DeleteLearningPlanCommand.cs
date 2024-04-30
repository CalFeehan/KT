using ErrorOr;
using MediatR;

namespace KT.Application.Learners.Commands.Delete;

public record DeleteLearningPlanCommand(Guid LearnerId, Guid Id) : IRequest<ErrorOr<Task>>;