namespace KT.Presentation.Contracts.V1.Responses.CourseTemplates;

public record ActivityPlanTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    List<ActivityTemplateResponse> ActivityTemplates);