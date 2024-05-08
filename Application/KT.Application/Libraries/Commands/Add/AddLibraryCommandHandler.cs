using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.LibraryAggregate;
using MediatR;

namespace KT.Application.Libraries.Commands.Add;

public class AddLibraryCommandHandler : IRequestHandler<AddLibraryCommand, ErrorOr<Library>>
{
    private readonly ILibraryRepository _libraryRepository;

    public AddLibraryCommandHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<ErrorOr<Library>> Handle(AddLibraryCommand command, CancellationToken cancellationToken)
    {
        var library = Library.Create();

        var created = await _libraryRepository.AddAsync(library);

        return created;
    }
}
