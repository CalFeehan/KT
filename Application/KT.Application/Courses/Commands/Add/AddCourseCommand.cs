using ErrorOr;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Commands.Add;

public record AddCourseCommand(
    Guid LearnerId,
    string Code,
    string Title,
    string Description,
    int Level,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    DateTime? ActualEndDate) : IRequest<ErrorOr<Course>>;
