using ErrorOr;
using MediatR;
using KT.Domain.Common.Errors;
using KT.Application.Common.Interfaces.Persistence;

namespace KT.Application.Sessions.Commands.Delete;

public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ErrorOr<Task>>
{
    private readonly ISessionRepository _sessionRepository;

    public DeleteCommandHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<ErrorOr<Task>> Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await _sessionRepository.DeleteAsync(command.Id);
        if (deletedCount is 0)
        {
            return Errors.Session.NotFound;
        }

        return Task.CompletedTask;
    }
}
