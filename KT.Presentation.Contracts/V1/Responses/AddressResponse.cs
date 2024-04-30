using KT.Domain.Common.Enums;

namespace KT.Presentation.Contracts;

public record AddressResponse(
    string Line1,
    string Line2,
    string City,
    County County,
    string PostCode);
