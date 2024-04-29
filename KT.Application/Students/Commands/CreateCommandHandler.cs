using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.StudentAggregate;
using MediatR;

namespace KT.Application.Students.Commands;

public class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<Student>>
{
    private readonly IStudentRepository _studentRepository;

    public CreateCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ErrorOr<Student>> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var student = Student.Create(command.Forename, command.Surname, command.DateOfBirth);

        var created = await _studentRepository.CreateAsync(student);

        return created;
    }
}