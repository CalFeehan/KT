using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

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

public record ModuleRequest(
    Guid CourseId,
    ModuleStatus ModuleStatus,
    string Code,
    string Title,
    string Description,
    int Level,
    AwardingOrganisation AwardingOrganisation,
    List<CriteriaRequest> Criteria);

public record CriteriaRequest(
    string Title,
    string Description,
    string Code,
    string CriteriaGroup);

