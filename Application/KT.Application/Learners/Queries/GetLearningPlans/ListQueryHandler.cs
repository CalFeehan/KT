using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.LearnerAggregate;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application.Learners.Queries.GetLearningPlans;

public class ListQueryHandler : IRequestHandler<ListQuery, ErrorOr<IList<LearningPlan>>>
{
    private readonly ILearnerRepository _learnerRepository;

    public ListQueryHandler(ILearnerRepository learnerRepository)
    {
        _learnerRepository = learnerRepository;
    }

    public async Task<ErrorOr<IList<LearningPlan>>> Handle(ListQuery request, CancellationToken cancellationToken)
    {
        var learner = await _learnerRepository.GetByIdAsync(request.LearnerId);
        if (learner is null)
        {
            return Errors.Learner.NotFound;
        }

        return learner.LearningPlans.ToList();
    }
}