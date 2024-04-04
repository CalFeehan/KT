using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Student;
using MediatR;

namespace KT.Application.Students.Commands;

public class CreateCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<CreateCommand, ErrorOr<Student>>
{
    public async Task<ErrorOr<Student>> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var student = new Student(command.Forename, command.Surname);

        var created = await studentRepository.CreateAsync(student);

        return created;
    }
}