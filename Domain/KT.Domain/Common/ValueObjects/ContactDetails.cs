using System.Text.Json.Serialization;
using KT.Common.Enums;
using KT.Domain.Common.Models;

namespace KT.Domain.Common.ValueObjects;

public class ContactDetails : ValueObject
{
    public string Email { get; }

    public string Phone { get; }

    public ContactPreference ContactPreference { get; }

    [JsonConstructor]
    private ContactDetails(string email, string phone, ContactPreference contactPreference)
    {
        Email = email;
        Phone = phone;
        ContactPreference = contactPreference;
    }

    public static ContactDetails Create(string email, string phone, ContactPreference contactPreference)
    {
        return new ContactDetails(email, phone, contactPreference);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
        yield return Phone;
        yield return ContactPreference;
    }
}