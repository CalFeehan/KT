using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Learners.Commands.Add;
using KT.Domain.Common.Errors;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application;

public class AddLearningPlanCommandHandler : IRequestHandler<AddLearningPlanCommand, ErrorOr<LearningPlan>>
{
    private readonly ILearnerRepository _learnerRepository;
    
    public AddLearningPlanCommandHandler(ILearnerRepository learnerRepository)
    {
        _learnerRepository = learnerRepository;
    }

    public async Task<ErrorOr<LearningPlan>> Handle(AddLearningPlanCommand request, CancellationToken cancellationToken)
    {
        var learner = await _learnerRepository.GetByIdAsync(request.LearnerId);
        if (learner is null)
        {
            return Errors.Learner.NotFound;
        }

        learner.AddLearningPlan(request.Title, request.Description);

        await _learnerRepository.UpdateAsync(learner);

        var learningPlan = learner.LearningPlans[learner.LearningPlans.Count - 1];

        return learningPlan;
    }

}
