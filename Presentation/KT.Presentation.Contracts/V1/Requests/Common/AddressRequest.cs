namespace KT.Presentation.Contracts.V1.Requests.Common;

public record AddressRequest(
    string Line1, 
    string Line2,
    string City, 
    string County, 
    string Postcode);