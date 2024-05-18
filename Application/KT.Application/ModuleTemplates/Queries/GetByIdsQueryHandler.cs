using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.ModuleTemplateAggregate;
using MediatR;

namespace KT.Application.ModuleTemplates.Queries;

public class GetByIdsQueryHandler(IModuleTemplateRepository moduleTemplateRepository)
    : IRequestHandler<GetByIdsQuery, ErrorOr<IList<ModuleTemplate>>>
{
    public async Task<ErrorOr<IList<ModuleTemplate>>> Handle(GetByIdsQuery query, CancellationToken cancellationToken)
    {
        var moduleTemplates = await moduleTemplateRepository.GetByIdsAsync(query.Ids);

        return moduleTemplates.ToList();
    }
}