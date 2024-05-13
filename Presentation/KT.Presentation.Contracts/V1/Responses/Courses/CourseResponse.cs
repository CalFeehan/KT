using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses.Courses;

public record CourseResponse(
    Guid Id,
    Guid LearnerId,
    CourseStatus CourseStatus,
    string Code,
    string Title,
    string Description,
    int Level,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    DateTime? ActualEndDate,
    List<ModuleResponse> Modules);