using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests;

public record AddModuleTemplateRequest(
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    List<CriteriaTemplateRequest> Criteria);

public record CriteriaTemplateRequest(
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks);