using ErrorOr;
using MediatR;
using KT.Domain.Common.Errors;
using KT.Application.Common.Interfaces.Persistence;

namespace KT.Application.Libraries.Commands.Delete;

public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ErrorOr<Task>>
{
    private readonly ILibraryRepository _libraryRepository;

    public DeleteCommandHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<ErrorOr<Task>> Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        var deletedCount = await _libraryRepository.DeleteAsync(command.Id);
        if (deletedCount is 0)
        {
            return Errors.Library.NotFound;
        }

        return Task.CompletedTask;
    }
}
