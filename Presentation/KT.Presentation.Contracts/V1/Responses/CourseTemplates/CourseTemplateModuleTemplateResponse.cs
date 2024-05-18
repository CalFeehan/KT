namespace KT.Presentation.Contracts.V1.Responses.CourseTemplates;

public record CourseTemplateModuleTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    Guid ModuleTemplateId);