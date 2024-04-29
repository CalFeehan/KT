using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.StudentAggregate;
using MediatR;

namespace KT.Application.Students.Commands;

public class CreateCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<CreateCommand, ErrorOr<Student>>
{
    public async Task<ErrorOr<Student>> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var student = Student.Create(command.Forename, command.Surname, command.DateOfBirth);

        var created = await studentRepository.CreateAsync(student);

        return created;
    }
}