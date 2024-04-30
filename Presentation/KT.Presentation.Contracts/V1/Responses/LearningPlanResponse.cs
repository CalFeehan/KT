namespace KT.Presentation.Contracts.V1.Responses;

public record LearningPlanResponse(
    Guid Id,
    Guid LearnerId,
    string Title,
    string Description,
    DateOnly StartDate,
    DateOnly ExpectedEndDate);