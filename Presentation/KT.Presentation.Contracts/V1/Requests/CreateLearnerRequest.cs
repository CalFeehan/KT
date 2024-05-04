namespace KT.Presentation.Contracts.V1.Requests;

public record CreateLearnerRequest(
    string Forename, 
    string Surname,
    DateTime DateOfBirth,
    AddressRequest Address,
    ContactDetailsRequest ContactDetails);

public record CreateLearningPlanRequest(
    string Title,
    string Description);