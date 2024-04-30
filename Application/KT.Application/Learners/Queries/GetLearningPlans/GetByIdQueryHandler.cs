using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application.Learners.Queries.GetLearningPlans;

public class GetByIdQueryHandler(ILearnerRepository learnerRepository)
    : IRequestHandler<GetByIdQuery, ErrorOr<LearningPlan>>
{
    public async Task<ErrorOr<LearningPlan>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var learner = await learnerRepository.GetByIdAsync(query.LearnerId);
        if (learner is null)
        {
            return Errors.Learner.NotFound;
        }

        var learningPlan = learner.LearningPlans.FirstOrDefault(x => x.Id == query.Id);
        if (learningPlan is null)
        {
            return Errors.LearningPlan.NotFound;
        }

        return learningPlan;
    }
}
