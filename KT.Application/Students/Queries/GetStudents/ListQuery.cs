using KT.Domain.StudentAggregate;
using MediatR;

namespace KT.Application.Students.Queries.GetStudents;

public record ListQuery : IRequest<IList<Student>>;