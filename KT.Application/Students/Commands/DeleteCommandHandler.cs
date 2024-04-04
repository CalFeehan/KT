using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.Students.Commands;

public class DeleteCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<DeleteCommand, ErrorOr<Task>>
{
    public async Task<ErrorOr<Task>> Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await studentRepository.DeleteAsync(command.Id);

        if (deletedCount is 0)
        {
            return Errors.Student.NotFound;
        }

        return Task.CompletedTask;
    }
}