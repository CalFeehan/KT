using KT.Domain.SessionAggregate;
using MediatR;

namespace KT.Application.Sessions.Queries;

public record ListQuery : IRequest<IList<Session>>;