using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Commands.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<Course>>
{
    private readonly ICourseRepository _courseRepository;

    public CreateCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<Course>> Handle(CreateCommand command, CancellationToken cancellationToken)
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

        var created = await _courseRepository.CreateAsync(course);

        return created;
    }
}
