using ErrorOr;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Queries.GetCourse;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Course>>;
