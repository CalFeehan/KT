using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.LibraryAggregate;
using MediatR;

namespace KT.Application.Libraries.Commands.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<Library>>
{
    private readonly ILibraryRepository _libraryRepository;

    public CreateCommandHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<ErrorOr<Library>> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var library = Library.Create();

        var created = await _libraryRepository.CreateAsync(library);
        if (created is null)
        {
            return Errors.Library.NotFound;
        }

        return created;
    }
}
