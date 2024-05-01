using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Courses.Queries.GetCourse;
using KT.Domain.CourseAggregate;
using MediatR;
using KT.Domain.Common.Errors;

namespace KT.Application.Courses.Queries.GetLearners;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ErrorOr<Course>>
{
    private readonly ICourseRepository _courseRepository;

    public GetByIdQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<Course>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(query.Id);
        if (course is null)
        {
            return Errors.Course.NotFound;
        }

        return course;
    }
}
