using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses.Courses;

public record ModuleResponse(
    Guid Id,
    Guid CourseId,
    ModuleStatus ModuleStatus,
    string Title,
    string Code,
    string Description,
    int Level,
    AwardingOrganisation AwardingOrganisation,
    List<CriteriaResponse> Criteria);