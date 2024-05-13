namespace KT.Presentation.Contracts.V1.Responses.CourseTemplates;

public record ScheduleDetailsResponse(
    int StartWeek,
    DayOfWeek DayOfWeek,
    TimeOnly StartTime,
    TimeSpan ExpectedDuration);