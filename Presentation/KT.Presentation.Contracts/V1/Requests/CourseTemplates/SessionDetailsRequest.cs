namespace KT.Presentation.Contracts.V1.Requests.CourseTemplates;
    
public record SessionDetailsRequest(
    int StartWeek,
    DayOfWeek DayOfWeek,
    TimeOnly StartTime,
    TimeSpan ExpectedDuration);