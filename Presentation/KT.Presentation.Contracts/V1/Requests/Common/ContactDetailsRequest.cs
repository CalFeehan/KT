using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests.Common;

public record ContactDetailsRequest(
    string Email,
    string Phone,
    ContactPreference ContactPreference);