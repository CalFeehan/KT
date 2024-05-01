using ErrorOr;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Queries.GetCourse;

public record ListQuery() : IRequest<IList<Course>>;
