using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Queries;

public class GetByIdQueryHandler(ILearnerRepository learnerRepository)
    : IRequestHandler<GetByIdQuery, ErrorOr<Learner>>
{
    public async Task<ErrorOr<Learner>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var learner = await learnerRepository.GetByIdAsync(query.Id);

        if (learner is null)
        {
            return Errors.Learner.NotFound;
        }

        return learner;
    }
}