using KT.Domain.Common.ValueObjects;

namespace KT.Presentation.Contracts.V1.Requests;

public record ContactDetailsRequest(
    string Email,
    string PhoneNumber,
    ContactPreference ContactPreference);
