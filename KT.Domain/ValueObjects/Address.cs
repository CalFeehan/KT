using KT.Domain.Common.Models;
using KT.Domain.Enums;

namespace KT.Domain.ValueObjects;

public class Address : ValueObject
{
    public string AddressLine1 { get; }

    public string AddressLine2 { get; } = string.Empty;

    public string City { get; }

    public County County { get; }

    public string Postcode { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return AddressLine1;
        yield return AddressLine2;
        yield return City;
        yield return County;
        yield return Postcode;
    }
}
