using ErrorOr;
using KT.Domain.CourseTemplateAggregate;
using MediatR;

namespace KT.Application.CourseTemplates.Commands.Add;

public record AddCourseTemplateCommand(
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInDays) : IRequest<ErrorOr<CourseTemplate>>;