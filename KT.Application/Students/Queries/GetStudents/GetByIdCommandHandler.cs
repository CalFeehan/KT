using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.Student;
using MediatR;

namespace KT.Application.Students.Queries.GetStudents;

public class GetByIdCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<GetByIdQuery, ErrorOr<Student>>
{
    public async Task<ErrorOr<Student>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetByIdAsync(query.Id);

        if (student is null)
        {
            return Errors.Student.NotFound;
        }

        return student;
    }
}