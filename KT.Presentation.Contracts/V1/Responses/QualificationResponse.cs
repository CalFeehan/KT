using KT.Domain.Qualification;

namespace KT.Presentation.Contracts.V1.Responses;

public record QualificationResponse(
    Guid Id,
    string Name,
    string Description,
    QualificationType QualificationType,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    DateTime? ActualEndDate,
    AwardingOrganisation AwardingOrganisation,
    int Level);