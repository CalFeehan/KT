using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.ModuleTemplateAggregate;
using MediatR;

namespace KT.Application.ModuleTemplates.Commands.Add;

public class AddModuleTemplateCommandHandler : IRequestHandler<AddModuleTemplateCommand, ErrorOr<ModuleTemplate>>
{
    private readonly IModuleTemplateRepository _moduleTemplateRepository;

    public AddModuleTemplateCommandHandler(IModuleTemplateRepository moduleTemplateRepository)
    {
        _moduleTemplateRepository = moduleTemplateRepository;
    }

    public async Task<ErrorOr<ModuleTemplate>> Handle(AddModuleTemplateCommand command,
        CancellationToken cancellationToken)
    {
        var moduleTemplate = ModuleTemplate.Create(
            command.ModuleType,
            command.Title,
            command.Description,
            command.Code,
            command.Level,
            command.DurationInWeeks);
        
        moduleTemplate.UpdateCriteriaTemplates(command.Criteria);
        
        var created = await _moduleTemplateRepository.AddAsync(moduleTemplate);

        return created;
    }
}