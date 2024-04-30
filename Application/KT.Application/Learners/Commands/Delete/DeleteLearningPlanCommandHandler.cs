using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.Learners.Commands.Delete;

public class DeleteLearningPlanCommandHandler(ILearnerRepository learnerRepository)
    : IRequestHandler<DeleteLearningPlanCommand, ErrorOr<Task>>
{
    public async Task<ErrorOr<Task>> Handle(DeleteLearningPlanCommand command, CancellationToken cancellationToken)
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