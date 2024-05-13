using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Queries;

public record ListQuery : IRequest<IList<Learner>>;