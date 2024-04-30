using ErrorOr;
using MediatR;

namespace KT.Application.Learners.Commands.Delete;

public record DeleteCommand(Guid Id) : IRequest<ErrorOr<Task>>;