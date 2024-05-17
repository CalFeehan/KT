using FluentValidation;
using KT.Application.Common.Interfaces.Persistence;
using KT.Common.Enums;
using KT.Common.Enums.Extensions;
using KT.Domain.CourseTemplateAggregate;

namespace KT.Application.CourseTemplates.Commands.Update;

public class UpdateCourseTemplateCommandValidator : AbstractValidator<UpdateCourseTemplateCommand>
{
    public UpdateCourseTemplateCommandValidator(
        ICourseTemplateRepository courseTemplateRepository,
        IModuleTemplateRepository moduleTemplateRepository)
    {
        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                OriginalCourseTemplate = await courseTemplateRepository.GetByIdAsync(command.Id);
                return OriginalCourseTemplate is not null;
            })
            .WithMessage("Course template not found.");

        RuleFor(x => x.ModuleTemplateIds)
            .MustAsync(async (moduleTemplateIds, cancellationToken) =>
            {
                var moduleTemplates = await moduleTemplateRepository.ListAsync();
                return moduleTemplateIds.All(
                    moduleTemplateId => moduleTemplates.Any(moduleTemplate => moduleTemplate.Id == moduleTemplateId));
            })
            .WithMessage("Module template not found.")
            .Must(NotContainDuplicates);
        
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.CourseTemplateStatus)
            .NotEmpty()
            .IsInEnum()
            .Must(BeAValidCourseTemplateStatusTransition);

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Level)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.DurationInWeeks)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.ActivityPlanTemplate)
            .NotEmpty();

        RuleFor(x => x.SessionPlanTemplate)
            .NotEmpty();
    }

    private CourseTemplate? OriginalCourseTemplate { get; set; }

    private static bool NotContainDuplicates(List<Guid> arg)
    {
        return arg.Distinct().Count() == arg.Count;
    }

    private bool BeAValidCourseTemplateStatusTransition(CourseTemplateStatus courseTemplateStatus)
    {
        if (OriginalCourseTemplate is null) return false;

        if (OriginalCourseTemplate!.CourseTemplateStatus == courseTemplateStatus) return true;

        return OriginalCourseTemplate!.CourseTemplateStatus.IsValidTransition(courseTemplateStatus);
    }
}