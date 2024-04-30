namespace KT.Presentation.Contracts.V1.Requests;

public record CreateLearningPlanRequest(
    string Title,
    string Description,
    DateOnly StartDate,
    DateOnly ExpectedEndDate);