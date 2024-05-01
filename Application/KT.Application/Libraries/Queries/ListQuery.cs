using KT.Domain.LibraryAggregate;
using MediatR;

namespace KT.Application.Libraries.Queries.GetCourse;

public record ListQuery() : IRequest<IList<Library>>;