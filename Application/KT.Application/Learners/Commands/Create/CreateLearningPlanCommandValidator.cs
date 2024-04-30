using FluentValidation;
using KT.Application.Learners.Commands.Create;

namespace KT.Application;

public class CreateLearningPlanCommandValidator : AbstractValidator<CreateLearningPlanCommand>
{
    public CreateLearningPlanCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.StartDate)
            .NotEmpty();

        RuleFor(x => x.ExpectedEndDate)
            .NotEmpty()
            .GreaterThan(x => x.StartDate);
    }
}
