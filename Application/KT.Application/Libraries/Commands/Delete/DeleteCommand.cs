using ErrorOr;
using MediatR;

namespace KT.Application.Libraries.Commands.Delete;

public record DeleteCommand(Guid Id) : IRequest<ErrorOr<Task>>;
