using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.Learners.Commands.Remove;

public class RemoveLearningPlanCommandHandler : IRequestHandler<RemoveLearningPlanCommand, ErrorOr<Task>>
{
    private readonly ILearnerRepository learnerRepository;

    public RemoveLearningPlanCommandHandler(ILearnerRepository learnerRepository)
    {
        this.learnerRepository = learnerRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveLearningPlanCommand command, CancellationToken cancellationToken)
    {
        // get learner
        var learner = await learnerRepository.GetByIdAsync(command.LearnerId);
        if (learner is null)
        {
            return Errors.Learner.NotFound;
        }

        // delete learning plan
        var learningPlan = learner.LearningPlans.FirstOrDefault(lp => lp.Id == command.Id);
        if (learningPlan is null)
        {
            return Errors.LearningPlan.NotFound;
        }

        learner.RemoveLearningPlan(learningPlan.Id);
        
        await learnerRepository.UpdateAsync(learner);

        return Task.CompletedTask;
    }
}