﻿using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.CourseAggregate;
using MediatR;

namespace KT.Application.Courses.Queries;

public class ListQueryHandler : IRequestHandler<ListQuery, IList<Course>>
{
    private readonly ICourseRepository _courseRepository;

    public ListQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IList<Course>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.ListAsync();

        return courses;
    }
}