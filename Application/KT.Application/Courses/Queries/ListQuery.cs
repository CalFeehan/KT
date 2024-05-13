using ErrorOr;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Queries;

public record ListQuery() : IRequest<IList<Course>>;
