using KT.Domain.Common.Models;

namespace KT.Domain.Common.ValueObjects;

public class ContactDetails(string emailAddress, string phoneNumber, ContactPreference contactPreference)
    : ValueObject
{
    public string EmailAddress { get; set; } = emailAddress;

    public string PhoneNumber { get; set; } = phoneNumber;

    public ContactPreference ContactPreference { get; set; } = contactPreference;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return EmailAddress;
        yield return PhoneNumber;
        yield return ContactPreference;
    }
}

public enum ContactPreference
{
    Email,
    Phone
}