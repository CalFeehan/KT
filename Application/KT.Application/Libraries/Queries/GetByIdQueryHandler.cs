using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Libraries.Queries.GetCourse;
using KT.Domain.LibraryAggregate;
using MediatR;
using KT.Domain.Common.Errors;

namespace KT.Application.Libraries.Queries.GetLearners;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ErrorOr<Library>>
{
    private readonly ILibraryRepository _libraryRepository;

    public GetByIdQueryHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<ErrorOr<Library>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var library = await _libraryRepository.GetByIdAsync(query.Id);
        if (library is null)
        {
            return Errors.Library.NotFound;
        }

        return library;
    }
}
