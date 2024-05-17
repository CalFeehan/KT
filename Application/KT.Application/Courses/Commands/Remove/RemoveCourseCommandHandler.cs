using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.Courses.Commands.Remove;

public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand, ErrorOr<Task>>
{
    private readonly ICourseRepository _courseRepository;

    public RemoveCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveCourseCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await _courseRepository.RemoveAsync(command.Id);
        if (deletedCount is 0) return Errors.Course.NotFound;

        return Task.CompletedTask;
    }
}