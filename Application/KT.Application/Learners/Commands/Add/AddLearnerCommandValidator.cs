using FluentValidation;
using KT.Application.Common.Validators;

namespace KT.Application.Learners.Commands.Add;

public class AddLearnerCommandValidator : AbstractValidator<AddLearnerCommand>
{
    public AddLearnerCommandValidator()
    {
        RuleFor(x => x.Forename).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateOfBirth).NotEmpty().GreaterThan(new DateOnly(1900, 1, 1));
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.ContactDetails).SetValidator(new ContactDetailsValidator());
    }
}