using ErrorOr;
using MediatR;
using KT.Domain.Common.Errors;
using KT.Application.Common.Interfaces.Persistence;

namespace KT.Application.Libraries.Commands.Remove;

public class RemoveLibraryCommandHandler : IRequestHandler<RemoveLibraryCommand, ErrorOr<Task>>
{
    private readonly ILibraryRepository _libraryRepository;

    public RemoveLibraryCommandHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveLibraryCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await _libraryRepository.RemoveAsync(command.Id);
        if (deletedCount is 0)
        {
            return Errors.Library.NotFound;
        }

        return Task.CompletedTask;
    }
}
