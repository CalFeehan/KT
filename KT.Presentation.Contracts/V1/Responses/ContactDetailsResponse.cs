
using KT.Domain.Common.Enums;

namespace KT.Presentation.Contracts;

public record ContactDetailsResponse(
    string Email, 
    string Phone, 
    ContactPreference ContactPreference);