namespace KT.Presentation.Contracts.V1.Requests;

public record CreateLearnerRequest(
    string Forename, 
    string Surname,
    DateOnly DateOfBirth,
    AddressRequest Address,
    ContactDetailsRequest ContactDetails);