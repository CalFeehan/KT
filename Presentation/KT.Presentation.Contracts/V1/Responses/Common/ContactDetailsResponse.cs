using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses.Common;

public record ContactDetailsResponse(
    string Email,
    string Phone,
    ContactPreference ContactPreference);