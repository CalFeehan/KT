using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.Sessions.Commands.Remove;

public class RemoveSessionCommandHandler : IRequestHandler<RemoveSessionCommand, ErrorOr<Task>>
{
    private readonly ISessionRepository _sessionRepository;

    public RemoveSessionCommandHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveSessionCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await _sessionRepository.RemoveAsync(command.Id);
        if (deletedCount is 0) return Errors.Session.NotFound;

        return Task.CompletedTask;
    }
}