using ErrorOr;
using MediatR;

namespace KT.Application.Libraries.Commands.Remove;

public record RemoveLibraryCommand(Guid Id) : IRequest<ErrorOr<Task>>;
