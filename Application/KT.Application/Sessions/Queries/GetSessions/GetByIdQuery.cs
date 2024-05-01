using ErrorOr;
using KT.Domain.SessionAggregate;
using MediatR;

namespace KT.Application.Sessions.Queries.GetSessions;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Session>>;
