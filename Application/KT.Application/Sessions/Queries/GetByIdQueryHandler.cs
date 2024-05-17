using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.SessionAggregate;
using MediatR;

namespace KT.Application.Sessions.Queries;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ErrorOr<Session>>
{
    private readonly ISessionRepository _sessionRepository;

    public GetByIdQueryHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<ErrorOr<Session>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var session = await _sessionRepository.GetByIdAsync(query.Id);
        if (session is null) return Errors.Session.NotFound;

        return session;
    }
}