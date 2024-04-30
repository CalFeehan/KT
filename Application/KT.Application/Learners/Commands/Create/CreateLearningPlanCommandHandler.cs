using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Learners.Commands.Create;
using KT.Domain.Common.Errors;
using KT.Domain.LearnerAggregate.Entities;
using MediatR;

namespace KT.Application;

public class CreateLearningPlanCommandHandler : IRequestHandler<CreateLearningPlanCommand, ErrorOr<LearningPlan>>
{
    private readonly ILearnerRepository _learnerRepository;
    
    public CreateLearningPlanCommandHandler(ILearnerRepository learnerRepository)
    {
        _learnerRepository = learnerRepository;
    }

    public async Task<ErrorOr<LearningPlan>> Handle(CreateLearningPlanCommand request, CancellationToken cancellationToken)
    {
        var learner = await _learnerRepository.GetByIdAsync(request.LearnerId);
        if (learner is null)
        {
            return Errors.Learner.NotFound;
        }

        learner.AddLearningPlan(request.Title, request.Description, request.StartDate, request.ExpectedEndDate);

        await _learnerRepository.UpdateAsync(learner);

        var learningPlan = learner.LearningPlans.Last();

        return learningPlan;
    }

}
