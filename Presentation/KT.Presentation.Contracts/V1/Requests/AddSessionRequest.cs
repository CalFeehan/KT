using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

public record AddSessionRequest(
    Guid Id,
    Guid CourseId,
    SessionType SessionType,
    DateTime StartTime,
    DateTime EndTime,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink);
