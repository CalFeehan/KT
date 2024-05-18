using ErrorOr;
using KT.Domain.ModuleTemplateAggregate;
using MediatR;

namespace KT.Application.ModuleTemplates.Queries;

public record GetByIdsQuery(IList<Guid> Ids) : IRequest<ErrorOr<IList<ModuleTemplate>>>;