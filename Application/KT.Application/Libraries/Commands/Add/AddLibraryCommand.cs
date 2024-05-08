using ErrorOr;
using KT.Domain.LibraryAggregate;
using MediatR;

namespace KT.Application.Libraries.Commands.Add;

public record AddLibraryCommand() : IRequest<ErrorOr<Library>>;