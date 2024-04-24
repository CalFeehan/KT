using KT.Domain.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

public record AddressRequest(
    string Line1, 
    string Line2, 
    County County, 
    string Postcode);