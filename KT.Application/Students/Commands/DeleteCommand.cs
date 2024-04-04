using ErrorOr;
using MediatR;

namespace KT.Application.Students.Commands;

public record DeleteCommand(Guid Id) : IRequest<ErrorOr<Task>>;