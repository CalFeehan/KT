using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

public record ContactDetailsRequest(
    string Email,
    string Phone,
    ContactPreference ContactPreference);
