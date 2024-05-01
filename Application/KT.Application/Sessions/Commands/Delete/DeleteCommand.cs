using ErrorOr;
using MediatR;

namespace KT.Application.Sessions.Commands.Delete;

public record DeleteCommand(Guid Id) : IRequest<ErrorOr<Task>>;
