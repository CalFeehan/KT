using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.ModuleTemplateAggregate;
using MediatR;

namespace KT.Application.ModuleTemplates.Queries;

public class ListQueryHandler(IModuleTemplateRepository moduleTemplateRepository)
    : IRequestHandler<ListQuery, IList<ModuleTemplate>>
{
    public async Task<IList<ModuleTemplate>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var moduleTemplates = await moduleTemplateRepository.ListAsync();
        
        return moduleTemplates;
    }
}