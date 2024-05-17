using ErrorOr;
using KT.Common.Enums;
using KT.Domain.CourseTemplateAggregate;
using KT.Domain.CourseTemplateAggregate.Entities;
using MediatR;

namespace KT.Application.CourseTemplates.Commands.Update;

public record UpdateCourseTemplateCommand(
    Guid Id,
    CourseTemplateStatus CourseTemplateStatus,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    ActivityPlanTemplate ActivityPlanTemplate,
    SessionPlanTemplate SessionPlanTemplate,
    List<Guid> ModuleTemplateIds)
    : IRequest<ErrorOr<CourseTemplate>>;