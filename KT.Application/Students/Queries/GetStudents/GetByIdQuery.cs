using ErrorOr;
using KT.Domain.StudentAggregate;
using MediatR;

namespace KT.Application.Students.Queries.GetStudents;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Student>>;