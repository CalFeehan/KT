namespace KT.Presentation.Contracts.V1.Requests;

public record AddLearnerRequest(
    string Forename, 
    string Surname,
    DateTime DateOfBirth,
    AddressRequest Address,
    ContactDetailsRequest ContactDetails);

public record AddLearningPlanRequest(
    string Title,
    string Description);