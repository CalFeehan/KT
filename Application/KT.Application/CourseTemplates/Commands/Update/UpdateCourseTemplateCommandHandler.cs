using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.CourseTemplateAggregate;
using KT.Domain.CourseTemplateAggregate.Extensions;
using MediatR;

namespace KT.Application.CourseTemplates.Commands.Update;

public class UpdateCourseTemplateCommandHandler : IRequestHandler<UpdateCourseTemplateCommand, ErrorOr<CourseTemplate>>
{
    private readonly ICourseTemplateRepository _courseTemplateRepository;

    public UpdateCourseTemplateCommandHandler(ICourseTemplateRepository courseTemplateRepository)
    {
        _courseTemplateRepository = courseTemplateRepository;
    }

    public async Task<ErrorOr<CourseTemplate>> Handle(UpdateCourseTemplateCommand request,
        CancellationToken cancellationToken)
    {
        var courseTemplate = await _courseTemplateRepository.GetByIdAsync(request.Id);
        if (courseTemplate is null) return Errors.CourseTemplate.NotFound;

        if (courseTemplate.IsEditable())
        {
            courseTemplate.UpdateBasicDetails(
                request.CourseTemplateStatus,
                request.Title,
                request.Description,
                request.Code,
                request.Level,
                request.DurationInWeeks);

            courseTemplate.UpdateActivityPlanTemplate(request.ActivityPlanTemplate);

            courseTemplate.UpdateSessionPlanTemplate(request.SessionPlanTemplate);

            courseTemplate.UpdateModuleTemplates(request.ModuleTemplateIds);
        }
        else
        {
            courseTemplate.UpdateCourseTemplateStatus(request.CourseTemplateStatus);
        }

        await _courseTemplateRepository.UpdateAsync(courseTemplate);

        return courseTemplate;
    }
}