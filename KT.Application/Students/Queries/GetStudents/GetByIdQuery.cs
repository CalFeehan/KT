using KT.Domain.Aggregates;
using MediatR;

namespace KT.Application.Students.Queries.GetStudents;

public record GetByIdQuery(Guid Id) : IRequest<Student>;