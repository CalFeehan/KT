﻿using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Requests.ModuleTemplates;

public record AddModuleTemplateRequest(
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    List<CriteriaTemplateRequest> Criteria);