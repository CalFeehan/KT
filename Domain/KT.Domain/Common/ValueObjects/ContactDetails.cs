using System.Text.Json.Serialization;
using KT.Common.Enums;
using KT.Domain.Common.Models;

namespace KT.Domain.Common.ValueObjects;

/// <summary>
/// Contact details are used to define how a person prefers to be contacted, and how to contact them.
/// </summary>
public class ContactDetails : ValueObject
{
    /// <summary>
    /// The email address of the person.
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// The phone number of the person.
    /// </summary>
    public string Phone { get; }

    /// <summary>
    /// The contact preference of the person. E.g., "Email", "Phone", etc.
    /// </summary>
    public ContactPreference ContactPreference { get; }

    /// <summary>
    /// Private constructor to ensure that the only way to create contact details is through the Create method.
    /// </summary>
    [JsonConstructor]
    private ContactDetails(string email, string phone, ContactPreference contactPreference)
    {
        Email = email;
        Phone = phone;
        ContactPreference = contactPreference;
    }

    /// <summary>
    /// Creates a new set of contact details.
    /// </summary>
    public static ContactDetails Create(string email, string phone, ContactPreference contactPreference)
    {
        return new ContactDetails(email, phone, contactPreference);
    }

    /// <summary>
    /// Compares two contact details for equality.
    /// </summary>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
        yield return Phone;
        yield return ContactPreference;
    }
}