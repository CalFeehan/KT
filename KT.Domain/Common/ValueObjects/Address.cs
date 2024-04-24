using KT.Domain.Common.Enums;
using KT.Domain.Common.Models;

namespace KT.Domain.Common.ValueObjects;

public class Address(string line1, string line2, string city, County county, string postcode)
    : ValueObject
{
    public string Line1 { get; } = line1;

    public string Line2 { get; } = line2;

    public string City { get; } = city;

    public County County { get; } = county;

    public string Postcode { get; } = postcode;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Line1;
        yield return Line2;
        yield return City;
        yield return County;
        yield return Postcode;
    }
}
