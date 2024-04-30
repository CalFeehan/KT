namespace KT.Presentation.Contracts.V1.Responses;

public record LearnerResponse(
    Guid Id, 
    string Forename, 
    string Surname,
    DateOnly DateOfBirth,
    AddressResponse Address,
    ContactDetailsResponse ContactDetails);