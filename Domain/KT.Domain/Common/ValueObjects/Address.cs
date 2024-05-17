using System.Text.Json.Serialization;
using KT.Domain.Common.Models;

namespace KT.Domain.Common.ValueObjects;

/// <summary>
///     An address is used to define a specific address for a person or organisation.
/// </summary>
public class Address : ValueObject
{
    /// <summary>
    ///     Private constructor to ensure that the only way to create an address is through the Create method.
    /// </summary>
    [JsonConstructor]
    private Address(string line1, string line2, string city, string county, string postcode)
    {
        Line1 = line1;
        Line2 = line2;
        City = city;
        County = county;
        Postcode = postcode;
    }

    /// <summary>
    ///     The first line of the address. E.g., "123 Main Street"
    /// </summary>
    public string Line1 { get; }

    /// <summary>
    ///     The second line of the address. E.g., "Apartment 1"
    /// </summary>
    public string Line2 { get; }

    /// <summary>
    ///     The city of the address. E.g., "London"
    /// </summary>
    public string City { get; }

    /// <summary>
    ///     The county of the address. E.g., "Greater London"
    /// </summary>
    public string County { get; }

    /// <summary>
    ///     The postcode of the address. E.g., "SW1A 1AA"
    /// </summary>
    public string Postcode { get; }

    /// <summary>
    ///     Creates a new address.
    /// </summary>
    public static Address Create(string line1, string line2, string city, string county, string postcode)
    {
        return new Address(line1, line2, city, county, postcode);
    }

    /// <summary>
    ///     Compares two addresses for equality.
    /// </summary>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Line1;
        yield return Line2;
        yield return City;
        yield return County;
        yield return Postcode;
    }
}