using ErrorOr;
using KT.Domain.Student;
using MediatR;

namespace KT.Application.Students.Queries.GetStudents;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Student>>;