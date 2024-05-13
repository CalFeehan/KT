namespace KT.Presentation.Contracts.V1.Requests.Courses;

public record CriteriaRequest(
    string Title,
    string Description,
    string Code,
    string CriteriaGroup);

