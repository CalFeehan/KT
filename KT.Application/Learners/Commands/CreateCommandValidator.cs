using FluentValidation;

namespace KT.Application.Learners.Commands;

public class CreateCommandValidator : AbstractValidator<CreateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(x => x.Forename).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateOfBirth).NotEmpty().GreaterThan(new DateOnly(1900, 1, 1));
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.ContactDetails).SetValidator(new ContactDetailsValidator());
    }
}
