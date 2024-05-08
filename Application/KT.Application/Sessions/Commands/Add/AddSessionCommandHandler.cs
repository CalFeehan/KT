using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.SessionAggregate;
using MediatR;

namespace KT.Application.Sessions.Commands.Add;

public class AddSessionCommandHandler : IRequestHandler<AddSessionCommand, ErrorOr<Session>>
{
    private readonly ISessionRepository _sessionRepository;

    public AddSessionCommandHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<ErrorOr<Session>> Handle(AddSessionCommand command, CancellationToken cancellationToken)
    {
        var session = Session.Create(
            command.CourseId,
            command.SessionType,
            command.StartTime,
            command.EndTime,
            command.CohortId,
            command.Location,
            command.Notes,
            command.MeetingLink
        );
        
        var created = await _sessionRepository.AddAsync(session);

        return created;
    }
}