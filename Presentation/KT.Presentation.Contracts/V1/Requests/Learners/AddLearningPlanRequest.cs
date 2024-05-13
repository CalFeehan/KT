namespace KT.Presentation.Contracts.V1.Requests.Learners;

public record AddLearningPlanRequest(
    string Title,
    string Description);