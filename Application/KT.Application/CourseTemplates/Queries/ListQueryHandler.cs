using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.CourseTemplateAggregate;
using MediatR;

namespace KT.Application.CourseTemplates.Queries;

public class ListQueryHandler : IRequestHandler<ListQuery, IList<CourseTemplate>>
{
    private readonly ICourseTemplateRepository _courseTemplateRepository;

    public ListQueryHandler(ICourseTemplateRepository courseTemplateRepository)
    {
        _courseTemplateRepository = courseTemplateRepository;
    }

    public async Task<IList<CourseTemplate>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var courseTemplates = await _courseTemplateRepository.ListAsync();
        
        return courseTemplates;
    }
}
