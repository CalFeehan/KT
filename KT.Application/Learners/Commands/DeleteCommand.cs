using ErrorOr;
using MediatR;

namespace KT.Application.Learners.Commands;

public record DeleteCommand(Guid Id) : IRequest<ErrorOr<Task>>;