using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.ModuleTemplates.Commands.Remove;

public class RemoveModuleTemplateCommandHandler : IRequestHandler<RemoveModuleTemplateCommand, ErrorOr<Task>>
{
    private readonly IModuleTemplateRepository _moduleTemplateRepository;

    public RemoveModuleTemplateCommandHandler(IModuleTemplateRepository moduleTemplateRepository)
    {
        _moduleTemplateRepository = moduleTemplateRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveModuleTemplateCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await _moduleTemplateRepository.RemoveAsync(command.Id);
        if (deletedCount is 0) return Errors.ModuleTemplate.NotFound;

        return Task.CompletedTask;
    }
}