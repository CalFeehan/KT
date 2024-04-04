using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Students.Queries.GetStudents;
using KT.Domain.Aggregates;
using MediatR;

namespace KT.Application.Students.Commands;

public class DeleteCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<DeleteCommand, int>
{
    public async Task<int> Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await studentRepository.DeleteAsync(command.Id);

        return deletedCount;
    }
}