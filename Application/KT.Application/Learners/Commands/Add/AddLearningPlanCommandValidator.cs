using FluentValidation;
using KT.Application.Learners.Commands.Add;

namespace KT.Application;

public class AddLearningPlanCommandValidator : AbstractValidator<AddLearningPlanCommand>
{
    public AddLearningPlanCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);
    }
}
