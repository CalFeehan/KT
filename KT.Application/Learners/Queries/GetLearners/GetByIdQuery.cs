using ErrorOr;
using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Queries.GetLearners;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Learner>>;