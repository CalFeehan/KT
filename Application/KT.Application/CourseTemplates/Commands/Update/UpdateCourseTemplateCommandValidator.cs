﻿using FluentValidation;
using KT.Application.Common.Interfaces.Persistence;
using KT.Common.Enums;
using KT.Common.Enums.Extensions;
using KT.Domain.CourseTemplateAggregate;
using KT.Domain.ModuleTemplateAggregate;

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

                ModuleTemplates = moduleTemplates.Where(x => moduleTemplateIds.Contains(x.Id)).ToList();

                return moduleTemplateIds.All(
                    moduleTemplateId => moduleTemplates.Any(moduleTemplate => moduleTemplate.Id == moduleTemplateId));
            })
            .WithMessage("Module template not found.")
            .Must(NotContainDuplicates)
            .Must(NotHaveModulesWithGreaterLevelThanCourseTemplateLevel)
            .WithMessage("Module templates must not have a level greater than the course template level.")
            .Must(NotHaveModulesWithGreaterDurationThanCourseTemplateDuration)
            .WithMessage("Module templates must not have a duration greater than the course template duration.");

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

    private List<ModuleTemplate> ModuleTemplates { get; set; } = new();

    private bool NotHaveModulesWithGreaterDurationThanCourseTemplateDuration(List<Guid> list)
    {
        return ModuleTemplates.Select(x => x.DurationInWeeks).Sum() <= OriginalCourseTemplate!.DurationInWeeks;
    }

    private bool NotHaveModulesWithGreaterLevelThanCourseTemplateLevel(List<Guid> list)
    {
        if (list.Count == 0) return true;

        return ModuleTemplates.Select(x => x.Level).Max() <= OriginalCourseTemplate!.Level;
    }

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