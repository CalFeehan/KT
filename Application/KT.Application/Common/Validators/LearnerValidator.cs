using FluentValidation;
using KT.Domain.LearnerAggregate;

namespace KT.Application;

public class LearnerValidator : AbstractValidator<Learner>
{
    public LearnerValidator()
    {
        RuleFor(x => x.Forename)
            .NotEmpty().WithMessage("Forename is required.")
            .MaximumLength(50).WithMessage("Forename must not exceed 50 characters.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname is required.")
            .MaximumLength(50).WithMessage("Surname must not exceed 50 characters.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past.");
    }

}
