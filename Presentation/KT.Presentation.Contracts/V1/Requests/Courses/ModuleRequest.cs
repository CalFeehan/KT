using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests.Courses;

public record ModuleRequest(
    Guid CourseId,
    ModuleStatus ModuleStatus,
    string Code,
    string Title,
    string Description,
    int Level,
    AwardingOrganisation AwardingOrganisation,
    List<CriteriaRequest> Criteria);