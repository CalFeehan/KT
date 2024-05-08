using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using MediatR;
using KT.Domain.Common.Errors;

namespace KT.Application.CourseTemplates.Commands.Remove;

public class RemoveCourseTemplateHandler : IRequestHandler<RemoveCourseTemplateCommand, ErrorOr<Task>>
{
    private readonly ICourseTemplateRepository _courseTemplateRepository;

    public RemoveCourseTemplateHandler(ICourseTemplateRepository courseTemplateRepository)
    {
        _courseTemplateRepository = courseTemplateRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveCourseTemplateCommand request, CancellationToken cancellationToken)
    {
        var courseTemplate = await _courseTemplateRepository.GetByIdAsync(request.CourseTemplateId);
        if (courseTemplate is null)
        {
            return Errors.CourseTemplate.NotFound;
        }

        await _courseTemplateRepository.RemoveAsync(request.CourseTemplateId);

        return Task.CompletedTask;
    }
}
