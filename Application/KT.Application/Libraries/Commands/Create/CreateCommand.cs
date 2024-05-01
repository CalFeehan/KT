using ErrorOr;
using KT.Domain.LibraryAggregate;
using MediatR;

namespace KT.Application.Libraries.Commands.Create;

public record CreateCommand() : IRequest<ErrorOr<Library>>;