using ErrorOr;
using MediatR;

namespace KT.Application.CourseTemplates.Commands.Remove;

public record RemoveCourseTemplateCommand(
    Guid CourseTemplateId) : IRequest<ErrorOr<Task>>;