using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using MediatR;
using KT.Domain.Common.Errors;
using KT.Domain.CourseTemplateAggregate;

namespace KT.Application.CourseTemplates.Queries;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ErrorOr<CourseTemplate>>
{
    private readonly ICourseTemplateRepository _courseTemplateRepository;

    public GetByIdQueryHandler(ICourseTemplateRepository courseTemplateRepository)
    {
        _courseTemplateRepository = courseTemplateRepository;
    }

    public async Task<ErrorOr<CourseTemplate>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var courseTemplate = await _courseTemplateRepository.GetByIdAsync(query.Id);
        if (courseTemplate is null)
        {
            return Errors.CourseTemplate.NotFound;
        }

        return courseTemplate;
    }
}
