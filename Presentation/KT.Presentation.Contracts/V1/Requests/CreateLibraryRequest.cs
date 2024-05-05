using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

public record CreateLibraryRequest(LibraryType LibraryType, List<CreateCourseTemplateRequest> CourseTemplates);

public record CreateCourseTemplateRequest(
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    List<CreateActivityPlanTemplateRequest> ActivityPlanTemplates,
    List<CreateSessionPlanTemplateRequest> SessionPlanTemplates,
    List<CreateModuleTemplateRequest> ModuleTemplates);

public record CreateSessionPlanTemplateRequest(
    List<CreateSessionTemplateRequest> SessionTemplates);

public record CreateSessionTemplateRequest(
    SessionType SessionType,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink,
    SessionDetailsRequest SessionDetailsRequest);

public record CreateActivityPlanTemplateRequest(
    List<CreateActivityTemplateRequest> ActivityTemplates);

public record CreateActivityTemplateRequest(
    string Title,
    string Description,
    List<Guid> DocumentIds,
    List<Guid> ModuleTemplateIds,
    SessionDetailsRequest SessionDetailsRequest);

public record CreateModuleTemplateRequest(
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks);

public record SessionDetailsRequest(
    int StartWeek,
    DayOfWeek DayOfWeek,
    TimeOnly StartTime,
    TimeSpan ExpectedDuration);

