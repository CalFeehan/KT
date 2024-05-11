using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.Learners.Commands.Remove;

public class RemoveLearnerCommandHandler : IRequestHandler<RemoveLearnerCommand, ErrorOr<Task>>
{
    private readonly ILearnerRepository learnerRepository;

    public RemoveLearnerCommandHandler(ILearnerRepository learnerRepository)
    {
        this.learnerRepository = learnerRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveLearnerCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await learnerRepository.RemoveAsync(command.Id);
        if (deletedCount is 0)
        {
            return Errors.Learner.NotFound;
        }

        return Task.CompletedTask;
    }
}