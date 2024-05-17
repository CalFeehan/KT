using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Queries;

public class ListQueryHandler(ILearnerRepository learnerRepository)
    : IRequestHandler<ListQuery, IList<Learner>>
{
    public async Task<IList<Learner>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var learners = await learnerRepository.ListAsync();

        return learners;
    }
}