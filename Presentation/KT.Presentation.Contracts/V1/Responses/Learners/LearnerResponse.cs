using KT.Presentation.Contracts.V1.Responses.Common;

namespace KT.Presentation.Contracts.V1.Responses.Learners;

public record LearnerResponse(
    Guid Id,
    string Forename,
    string Surname,
    DateTime DateOfBirth,
    AddressResponse Address,
    ContactDetailsResponse ContactDetails);