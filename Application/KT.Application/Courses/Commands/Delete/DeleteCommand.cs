using ErrorOr;
using MediatR;

namespace KT.Application.Courses.Commands.Delete;

public record DeleteCommand(Guid Id) : IRequest<ErrorOr<Task>>;
