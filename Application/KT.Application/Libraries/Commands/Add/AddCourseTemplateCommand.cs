using ErrorOr;
using KT.Domain.LibraryAggregate.Entities;
using MediatR;

namespace KT.Application.Libraries.Commands.Add;

public record AddCourseTemplateCommand(
    Guid LibraryId,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInDays) : IRequest<ErrorOr<CourseTemplate>>;
