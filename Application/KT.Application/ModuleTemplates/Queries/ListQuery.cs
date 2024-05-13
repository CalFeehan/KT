using KT.Domain.ModuleTemplateAggregate;
using MediatR;

namespace KT.Application.ModuleTemplates.Queries;

public record ListQuery : IRequest<IList<ModuleTemplate>>;