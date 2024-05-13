using ErrorOr;
using KT.Domain.ModuleTemplateAggregate;
using MediatR;

namespace KT.Application.ModuleTemplates.Queries;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<ModuleTemplate>>;