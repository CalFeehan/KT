namespace KT.Presentation.Contracts.V1.Responses.ModuleTemplates;

public record CriteriaTemplateResponse(
    string Title,
    string Description,
    string Code,
    string CriteriaGroup);