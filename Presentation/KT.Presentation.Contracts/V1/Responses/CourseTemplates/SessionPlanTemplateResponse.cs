namespace KT.Presentation.Contracts.V1.Responses.CourseTemplates;

public record SessionPlanTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    List<SessionTemplateResponse> SessionTemplates);