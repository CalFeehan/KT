using KT.Domain.Common.ValueObjects;

namespace KT.Application.Tests;

public static class AddressHelpers
{
    public static Address DummyAddress => Address.Create("123 Fake Street", "Fake Road", "Fake City", "Fake County", "AA11 1AA");
}
