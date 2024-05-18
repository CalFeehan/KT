namespace KT.Presentation.Contracts.V1.Requests.ModuleTemplates;

public record CriteriaTemplateRequest(
    string Title,
    string Description,
    string Code,
    string Group);