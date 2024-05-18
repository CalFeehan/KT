using ErrorOr;
using KT.Common.Enums;
using KT.Domain.ModuleTemplateAggregate;
using KT.Domain.ModuleTemplateAggregate.ValueObjects;
using MediatR;

namespace KT.Application.ModuleTemplates.Commands.Add;

public record AddModuleTemplateCommand(
    ModuleType ModuleType,
    string Title,
    string Description,
    string Code,
    int Level,
    int DurationInWeeks,
    List<CriteriaTemplate> Criteria)
    : IRequest<ErrorOr<ModuleTemplate>>;