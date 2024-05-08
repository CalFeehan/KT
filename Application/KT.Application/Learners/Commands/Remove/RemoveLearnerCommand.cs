using ErrorOr;
using MediatR;

namespace KT.Application.Learners.Commands.Remove;

public record RemoveLearnerCommand(Guid Id) : IRequest<ErrorOr<Task>>;