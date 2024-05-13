namespace KT.Presentation.Contracts.V1.Requests.Courses;

public record AddCourseRequest(
    List<ModuleRequest> Modules,
    Guid LearnerId,
    string Code,
    string Title,
    string Description,
    int Level,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    DateTime? ActualEndDate);