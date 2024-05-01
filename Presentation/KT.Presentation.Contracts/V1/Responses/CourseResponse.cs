using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses;

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

public record CriteriaResponse(
    string Title,
    string Description,
    string Code,
    string CriteriaGroup);


