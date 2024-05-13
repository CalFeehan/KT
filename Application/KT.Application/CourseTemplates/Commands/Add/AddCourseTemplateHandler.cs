using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.CourseTemplateAggregate;
using MediatR;

namespace KT.Application.CourseTemplates.Commands.Add;

public class AddCourseTemplateHandler : IRequestHandler<AddCourseTemplateCommand, ErrorOr<CourseTemplate>>
{
    private readonly ICourseTemplateRepository _courseTemplateRepository;

    public AddCourseTemplateHandler(ICourseTemplateRepository courseTemplateRepository)
    {
        _courseTemplateRepository = courseTemplateRepository;
    }

    public async Task<ErrorOr<CourseTemplate>> Handle(AddCourseTemplateCommand request, CancellationToken cancellationToken)
    {
        var courseTemplate = CourseTemplate.Create(request.Title, request.Description, request.Code, request.Level, request.DurationInDays);

        var created = await _courseTemplateRepository.AddAsync(courseTemplate);

        return created;
    }
}
