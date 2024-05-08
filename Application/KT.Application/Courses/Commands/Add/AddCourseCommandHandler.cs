using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Commands.Add;

public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, ErrorOr<Course>>
{
    private readonly ICourseRepository _courseRepository;

    public AddCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<Course>> Handle(AddCourseCommand command, CancellationToken cancellationToken)
    {
        var course = Course.Create(
            command.LearnerId,
            command.Code,
            command.Title,
            command.Description,
            command.Level,
            command.StartDate,
            command.ExpectedEndDate,
            command.ActualEndDate);

        var created = await _courseRepository.AddAsync(course);

        return created;
    }
}
