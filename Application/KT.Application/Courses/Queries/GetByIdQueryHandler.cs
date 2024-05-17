using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Queries;

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
        if (course is null) return Errors.Course.NotFound;

        return course;
    }
}