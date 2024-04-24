using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Student;
using MediatR;

namespace KT.Application.Students.Queries.GetStudents;

public class ListQueryHandler(IStudentRepository studentRepository)
    : IRequestHandler<ListQuery, IList<Student>>
{
    public async Task<IList<Student>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var students = await studentRepository.ListAsync();
        
        return students;
    }
}