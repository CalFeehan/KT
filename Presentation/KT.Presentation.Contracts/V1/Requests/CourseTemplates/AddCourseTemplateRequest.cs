namespace KT.Presentation.Contracts.V1.Requests.CourseTemplates;

public record AddCourseTemplateRequest(
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks);