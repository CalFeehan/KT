using ErrorOr;
using MediatR;

namespace KT.Application.Courses.Commands.Remove;

public record RemoveCourseCommand(Guid Id) : IRequest<ErrorOr<Task>>;
