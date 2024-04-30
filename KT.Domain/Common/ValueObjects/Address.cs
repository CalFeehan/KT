using System.Text.Json.Serialization;
using KT.Domain.Common.Enums;
using KT.Domain.Common.Models;

namespace KT.Domain.Common.ValueObjects;

public class Address : ValueObject
{
    public string Line1 { get; }

    public string Line2 { get; }

    public string City { get; }

    public County County { get; }

    public string Postcode { get; }

    [JsonConstructor]
    private Address(string line1, string line2, string city, County county, string postcode)
    {
        Line1 = line1;
        Line2 = line2;
        City = city;
        County = county;
        Postcode = postcode;
    }

    public static Address Create(string line1, string line2, string city, County county, string postcode)
    {
        return new Address(line1, line2, city, county, postcode);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Line1;
        yield return Line2;
        yield return City;
        yield return County;
        yield return Postcode;
    }
}
