using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses.CourseTemplates;

public record CourseTemplateResponse(
    Guid Id,
    CourseTemplateStatus CourseTemplateStatus,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    ActivityPlanTemplateResponse ActivityPlanTemplate,
    SessionPlanTemplateResponse SessionPlanTemplate,
    List<CourseTemplateModuleTemplateResponse> CourseTemplateModuleTemplates);