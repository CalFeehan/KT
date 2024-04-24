using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Qualification;
using MediatR;

namespace KT.Application.Qualifications.Queries.GetQualifications;

public class ListQueryHandler(IQualificationRepository qualificationRepository)
    : IRequestHandler<ListQuery, IList<Qualification>>
{
    public async Task<IList<Qualification>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var qualifications = await qualificationRepository.ListAsync();

        return qualifications;
    }
}