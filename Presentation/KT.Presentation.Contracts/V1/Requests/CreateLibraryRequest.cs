using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

public record CreateLibraryRequest(LibraryType LibraryType, List<CreateCourseTemplateRequest> CourseTemplates);

public record CreateCourseTemplateRequest(
    string Title,
    string Description,
    List<CreateActivityPlanTemplateRequest> ActivityPlanTemplates,
    List<CreateSessionPlanTemplateRequest> SessionPlanTemplates,
    List<CreateModuleTemplateRequest> ModuleTemplates
);

public record CreateSessionPlanTemplateRequest(List<CreateSessionTemplateRequest> SessionTemplates);

public record CreateSessionTemplateRequest(
    SessionType SessionType,
    DateTime StartTime,
    DateTime EndTime,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink
);

public record CreateActivityPlanTemplateRequest(List<CreateActivityTemplateRequest> ActivityTemplates);

public record CreateActivityTemplateRequest(
    string Title,
    string Description,
    TimeSpan Duration,
    List<Guid> DocumentIds,
    List<Guid> ModuleTemplateIds
);

public record CreateModuleTemplateRequest(
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    DateTime? ActualEndDate
);

