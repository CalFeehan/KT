using ErrorOr;
using MediatR;

namespace KT.Application.ModuleTemplates.Commands.Remove;

public record RemoveModuleTemplateCommand(Guid Id) : IRequest<ErrorOr<Task>>;