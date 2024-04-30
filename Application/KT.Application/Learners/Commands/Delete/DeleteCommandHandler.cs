using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using MediatR;

namespace KT.Application.Learners.Commands.Delete;

public class DeleteCommandHandler(ILearnerRepository learnerRepository)
    : IRequestHandler<DeleteCommand, ErrorOr<Task>>
{
    public async Task<ErrorOr<Task>> Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await learnerRepository.DeleteAsync(command.Id);

        if (deletedCount is 0)
        {
            return Errors.Learner.NotFound;
        }

        return Task.CompletedTask;
    }
}