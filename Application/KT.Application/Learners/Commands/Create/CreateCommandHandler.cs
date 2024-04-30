using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Commands.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<Learner>>
{
    private readonly ILearnerRepository _learnerRepository;

    public CreateCommandHandler(ILearnerRepository learnerRepository)
    {
        _learnerRepository = learnerRepository;
    }

    public async Task<ErrorOr<Learner>> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var learner = Learner.Create(
            command.Forename, command.Surname, command.DateOfBirth,
            command.Address.Line1, command.Address.Line2, command.Address.City, command.Address.County, command.Address.Postcode,
            command.ContactDetails.Email, command.ContactDetails.Phone, command.ContactDetails.ContactPreference);

        var created = await _learnerRepository.CreateAsync(learner);

        return created;
    }
}