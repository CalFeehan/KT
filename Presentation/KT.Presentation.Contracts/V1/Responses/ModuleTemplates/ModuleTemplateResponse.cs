﻿using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses.ModuleTemplates;

public record ModuleTemplateResponse(
    Guid Id,
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    List<CriteriaTemplateResponse> CriteriaTemplates);