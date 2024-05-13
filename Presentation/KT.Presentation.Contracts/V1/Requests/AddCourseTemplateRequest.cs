using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

public record AddCourseTemplateRequest(
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks);

public record AddSessionPlanTemplateRequest(
    List<AddSessionTemplateRequest> SessionTemplates);

public record AddSessionTemplateRequest(
    SessionType SessionType,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink,
    SessionDetailsRequest SessionDetailsRequest);

public record AddActivityPlanTemplateRequest(
    List<AddActivityTemplateRequest> ActivityTemplates);

public record AddActivityTemplateRequest(
    string Title,
    string Description,
    List<Guid> DocumentIds,
    List<Guid> ModuleTemplateIds,
    SessionDetailsRequest SessionDetailsRequest);
    
public record SessionDetailsRequest(
    int StartWeek,
    DayOfWeek DayOfWeek,
    TimeOnly StartTime,
    TimeSpan ExpectedDuration);

