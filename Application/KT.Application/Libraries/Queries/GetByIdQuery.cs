using ErrorOr;
using KT.Domain.LibraryAggregate;
using MediatR;

namespace KT.Application.Libraries.Queries.GetCourse;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<Library>>;