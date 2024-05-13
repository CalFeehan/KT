using FluentValidation;
using KT.Application.Common.Interfaces.Persistence;
using KT.Common.Enums;
using KT.Domain.CourseTemplateAggregate;

namespace KT.Application.CourseTemplates.Commands.Update;

public class UpdateCourseTemplateCommandValidator : AbstractValidator<UpdateCourseTemplateCommand>
{
    private CourseTemplate? OriginalCourseTemplate { get; set; }

    public UpdateCourseTemplateCommandValidator(ICourseTemplateRepository courseTemplateRepository)
    {
        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                OriginalCourseTemplate = await courseTemplateRepository.GetByIdAsync(command.Id);
                return OriginalCourseTemplate is not null;
            })
            .WithMessage("Course template not found.");

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
            .NotEmpty();

        RuleFor(x => x.DurationInWeeks)
            .NotEmpty();

        RuleFor(x => x.ActivityPlanTemplate)
            .NotEmpty();

        RuleFor(x => x.SessionPlanTemplate)
            .NotEmpty();

        RuleFor(x => x.ModuleTemplateIds)
            .NotEmpty();
    }

    private bool BeAValidCourseTemplateStatusTransition(CourseTemplateStatus courseTemplateStatus)
    {
        if (OriginalCourseTemplate!.CourseTemplateStatus == courseTemplateStatus)
        {
            return true;
        }

        return OriginalCourseTemplate!.CourseTemplateStatus.IsValidTransition(courseTemplateStatus);
    }
}
