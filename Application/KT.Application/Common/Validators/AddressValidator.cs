using FluentValidation;
using KT.Domain.Common.ValueObjects;

namespace KT.Application.Common.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Line1).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Line2).NotEmpty().MaximumLength(100);
        RuleFor(x => x.City).NotEmpty().MaximumLength(50);
        RuleFor(x => x.County).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Postcode).NotEmpty().MaximumLength(10);
    }
}