using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Queries.GetLearners;

public record ListQuery : IRequest<IList<Learner>>;