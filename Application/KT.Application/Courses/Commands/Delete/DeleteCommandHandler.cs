using ErrorOr;
using MediatR;
using KT.Domain.Common.Errors;
using KT.Application.Common.Interfaces.Persistence;

namespace KT.Application.Courses.Commands.Delete;

public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ErrorOr<Task>>
{
    private readonly ICourseRepository _courseRepository;

    public DeleteCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<Task>> Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await _courseRepository.DeleteAsync(command.Id);
        if (deletedCount is 0)
        {
            return Errors.Course.NotFound;
        }

        return Task.CompletedTask;
    }
}
