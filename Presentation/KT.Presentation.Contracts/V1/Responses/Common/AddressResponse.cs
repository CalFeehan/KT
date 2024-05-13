namespace KT.Presentation.Contracts.V1.Responses.Common;

public record AddressResponse(
    string Line1,
    string Line2,
    string City,
    string County,
    string PostCode);
