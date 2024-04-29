using KT.Domain.Common.Models;

namespace KT.Domain.Common.ValueObjects;

public class ContactDetails(string email, string phone, ContactPreference contactPreference)
    : ValueObject
{
    public string Email { get; set; } = email;

    public string Phone { get; set; } = phone;

    public ContactPreference ContactPreference { get; set; } = contactPreference;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
        yield return Phone;
        yield return ContactPreference;
    }
}

public enum ContactPreference
{
    Email,
    Phone
}