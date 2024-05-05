using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses;

public record LibraryResponse(Guid Id, List<CourseTemplateResponse> CourseTemplates);

public record CourseTemplateResponse(
    Guid Id,
    Guid LibraryId,
    CourseTemplateStatus CourseTemplateStatus,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    ActivityPlanTemplateResponse ActivityPlanTemplate,
    SessionPlanTemplateResponse SessionPlanTemplate,
    List<ModuleTemplateResponse> ModuleTemplates);

public record SessionPlanTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    List<SessionTemplateResponse> SessionTemplates);

public record SessionTemplateResponse(
    Guid Id,
    Guid SessionPlanTemplateId,
    SessionType SessionType,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink,
    ScheduleDetailsResponse ScheduleDetails);

public record ActivityPlanTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    List<ActivityTemplateResponse> ActivityTemplates);

public record ActivityTemplateResponse(
    Guid Id,
    Guid ActivityPlanTemplateId,
    string Title,
    string Description,
    List<Guid> DocumentIds,
    List<Guid> ModuleTemplateIds,
    ScheduleDetailsResponse ScheduleDetails);


public record ModuleTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    List<CriteriaTemplateResponse> CriteriaTemplates);

public record CriteriaTemplateResponse(
    string Title,
    string Description,
    string Code,
    string CriteriaGroup);

public record ScheduleDetailsResponse(
    int StartWeek,
    DayOfWeek DayOfWeek,
    TimeOnly StartTime,
    TimeSpan ExpectedDuration);

