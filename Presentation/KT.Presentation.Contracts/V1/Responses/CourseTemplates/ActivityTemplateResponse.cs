namespace KT.Presentation.Contracts.V1.Responses.CourseTemplates;

public record ActivityTemplateResponse(
    Guid Id,
    Guid ActivityPlanTemplateId,
    string Title,
    string Description,
    List<Guid> DocumentIds,
    List<Guid> ModuleTemplateIds,
    ScheduleDetailsResponse ScheduleDetails);