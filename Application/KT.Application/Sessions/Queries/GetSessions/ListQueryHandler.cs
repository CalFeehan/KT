using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.SessionAggregate;
using MediatR;

namespace KT.Application.Sessions.Queries.GetSessions;

public class ListQueryHandler : IRequestHandler<ListQuery, IList<Session>>
{
    private readonly ISessionRepository _sessionRepository;

    public ListQueryHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<IList<Session>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var sessions = await _sessionRepository.ListAsync();
        
        return sessions;
    }
}