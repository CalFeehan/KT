using ErrorOr;
using KT.Domain.Qualification;
using MediatR;

namespace KT.Application.Qualifications.Queries.GetQualifications;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Qualification>>;