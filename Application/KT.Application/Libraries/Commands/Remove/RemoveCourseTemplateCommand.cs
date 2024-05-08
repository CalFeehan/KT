using ErrorOr;
using MediatR;

namespace KT.Application.Libraries.Commands.Remove;

public record RemoveCourseTemplateCommand(
    Guid LibraryId,
    Guid CourseTemplateId) : IRequest<ErrorOr<Task>>;
