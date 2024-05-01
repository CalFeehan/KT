namespace KT.Application.Sessions.Queries.GetSessions;

using ErrorOr;
using KT.Domain.SessionAggregate;
using MediatR;
using System.Collections.Generic;

public record ListQuery : IRequest<IList<Session>>;