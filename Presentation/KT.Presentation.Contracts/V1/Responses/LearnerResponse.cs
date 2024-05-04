namespace KT.Presentation.Contracts.V1.Responses;

public record LearnerResponse(
    Guid Id, 
    string Forename, 
    string Surname,
    DateTime DateOfBirth,
    AddressResponse Address,
    ContactDetailsResponse ContactDetails);

public record LearningPlanResponse(
    Guid Id,
    Guid LearnerId,
    string Title,
    string Description);