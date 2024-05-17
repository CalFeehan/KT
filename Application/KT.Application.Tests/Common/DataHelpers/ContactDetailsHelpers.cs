using KT.Common.Enums;
using KT.Domain.Common.ValueObjects;

namespace KT.Application.Tests.Common.DataHelpers;

public static class ContactDetailsHelpers
{
    public static ContactDetails DummyContactDetails =>
        ContactDetails.Create("email@email.com", "1234567890", ContactPreference.Email);
}