using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses;

public record SessionResponse(
    Guid Id,
    Guid CourseId,
    SessionType SessionType,
    DateTime StartTime,
    DateTime EndTime,
    TimeSpan Duration,
    Guid? CohortId,
    bool IsCohortSession,
    string Location,
    string Notes,
    string MeetingLink);
