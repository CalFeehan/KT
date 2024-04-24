using KT.Domain.Qualification;

namespace KT.Presentation.Contracts.V1.Requests;

public record CreateQualificationRequest(
    string Name,
    string Description,
    QualificationType QualificationType,
    DateOnly StartDate,
    DateOnly ExpectedEndDate,
    DateOnly? ActualEndDate,
    AwardingOrganisation AwardingOrganisation,
    int Level
);
