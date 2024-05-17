using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Commands.Add;

public class AddLearnerCommandHandler : IRequestHandler<AddLearnerCommand, ErrorOr<Learner>>
{
    private readonly ILearnerRepository _learnerRepository;

    public AddLearnerCommandHandler(ILearnerRepository learnerRepository)
    {
        _learnerRepository = learnerRepository;
    }

    public async Task<ErrorOr<Learner>> Handle(AddLearnerCommand command, CancellationToken cancellationToken)
    {
        var learner = Learner.Create(command.Forename, command.Surname, command.DateOfBirth, command.Address,
            command.ContactDetails);

        var created = await _learnerRepository.AddAsync(learner);

        return created;
    }
}