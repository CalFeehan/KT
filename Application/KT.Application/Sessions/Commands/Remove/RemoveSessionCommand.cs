using ErrorOr;
using MediatR;

namespace KT.Application.Sessions.Commands.Remove;

public record RemoveSessionCommand(Guid Id) : IRequest<ErrorOr<Task>>;
