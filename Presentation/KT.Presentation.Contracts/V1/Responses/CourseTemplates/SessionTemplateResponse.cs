using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses.CourseTemplates;

public record SessionTemplateResponse(
    Guid Id,
    Guid SessionPlanTemplateId,
    SessionType SessionType,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink,
    ScheduleDetailsResponse ScheduleDetails);