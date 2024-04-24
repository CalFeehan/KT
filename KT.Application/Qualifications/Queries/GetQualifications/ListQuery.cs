using KT.Domain.Qualification;
using MediatR;

namespace KT.Application.Qualifications.Queries.GetQualifications;

public record ListQuery : IRequest<IList<Qualification>>;
