using ErrorOr;
using KT.Domain.SessionAggregate;
using MediatR;

namespace KT.Application.Sessions.Queries;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Session>>;
