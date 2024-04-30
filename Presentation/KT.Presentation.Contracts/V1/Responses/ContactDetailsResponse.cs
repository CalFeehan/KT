
using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses;

public record ContactDetailsResponse(
    string Email, 
    string Phone, 
    ContactPreference ContactPreference);