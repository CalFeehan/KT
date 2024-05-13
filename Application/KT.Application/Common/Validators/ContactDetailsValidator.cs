using FluentValidation;
using KT.Domain.Common.ValueObjects;

namespace KT.Application.Common.Validators;

public class ContactDetailsValidator : AbstractValidator<ContactDetails>
{
    public ContactDetailsValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(100).EmailAddress();
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(11);
        RuleFor(x => x.ContactPreference).IsInEnum();
    }
}
