﻿using KT.Common.Enums;

namespace KT.Presentation.Contracts.V1.Responses;

public record LibraryResponse(Guid Id);

public record CourseTemplateResponse(
    Guid Id,
    Guid LibraryId,
    CourseTemplateStatus CourseTemplateStatus,
    string Title,
    string Description,
    string Code,
    int Level,
    SessionPlanTemplateResponse SessionPlanTemplate,
    List<ModuleTemplateResponse> ModuleTemplates);

public record SessionPlanTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    List<SessionTemplateResponse> SessionTemplates);

public record SessionTemplateResponse(
    Guid Id,
    Guid SessionPlanTemplateId,
    SessionType SessionType,
    DateTime StartTime,
    DateTime EndTime,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink);


public record ModuleTemplateResponse(
    Guid Id,
    Guid CourseTemplateId,
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    DateTime? ActualEndDate,
    List<CriteriaTemplateResponse> CriteriaTemplates);

public record CriteriaTemplateResponse(
    string Title,
    string Description,
    string Code,
    string CriteriaGroup);
