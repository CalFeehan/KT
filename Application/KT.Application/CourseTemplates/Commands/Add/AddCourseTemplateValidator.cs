using FluentValidation;
using KT.Domain.CourseTemplateAggregate;

namespace KT.Application.CourseTemplates.Commands.Add;

public class AddCourseTemplateValidator : AbstractValidator<CourseTemplate>
{
    public AddCourseTemplateValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(25);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.DurationInWeeks).GreaterThan(0);
        RuleFor(x => x.Level).GreaterThan(0);
    }
}