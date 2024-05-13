namespace KT.Presentation.Contracts.V1.Requests.CourseTemplates;

public record AddActivityTemplateRequest(
    string Title,
    string Description,
    List<Guid> DocumentIds,
    List<Guid> ModuleTemplateIds,
    SessionDetailsRequest SessionDetailsRequest);