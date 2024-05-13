using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests.CourseTemplates;

public record AddSessionTemplateRequest(
    SessionType SessionType,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink,
    SessionDetailsRequest SessionDetailsRequest);