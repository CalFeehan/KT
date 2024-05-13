namespace KT.Presentation.Contracts.V1.Responses.Learners;

public record LearningPlanResponse(
    Guid Id,
    Guid LearnerId,
    string Title,
    string Description);