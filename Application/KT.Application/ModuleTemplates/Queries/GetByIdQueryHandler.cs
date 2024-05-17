using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.ModuleTemplateAggregate;
using MediatR;

namespace KT.Application.ModuleTemplates.Queries;

public class GetByIdQueryHandler(IModuleTemplateRepository moduleTemplateRepository)
    : IRequestHandler<GetByIdQuery, ErrorOr<ModuleTemplate>>
{
    public async Task<ErrorOr<ModuleTemplate>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var moduleTemplate = await moduleTemplateRepository.GetByIdAsync(query.Id);
        if (moduleTemplate is null) return Errors.ModuleTemplate.NotFound;

        return moduleTemplate;
    }
}