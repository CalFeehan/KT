using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Aggregates;
using MediatR;

namespace KT.Application.Students.Queries.GetStudents;

public class GetByIdCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<GetByIdQuery, Student>
{
    public async Task<Student> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetByIdAsync(query.Id);

        return student;
    }
}