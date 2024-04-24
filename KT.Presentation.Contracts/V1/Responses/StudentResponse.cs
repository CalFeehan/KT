namespace KT.Presentation.Contracts.V1.Responses;

public record StudentResponse(
    Guid Id, 
    string Forename, 
    string Surname,
    DateOnly DateOfBirth);