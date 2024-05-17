using ErrorOr;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Queries;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Course>>;