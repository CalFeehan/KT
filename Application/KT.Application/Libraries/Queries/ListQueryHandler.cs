using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Libraries.Queries.GetCourse;
using KT.Domain.LibraryAggregate;
using MediatR;

namespace KT.Application.Libraries.Queries.GetLearners;

public class ListQueryHandler : IRequestHandler<ListQuery, IList<Library>>
{
    private readonly ILibraryRepository _libraryRepository;

    public ListQueryHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<IList<Library>> Handle(ListQuery query, CancellationToken cancellationToken)
    {
        var libraries = await _libraryRepository.ListAsync();
        
        return libraries;
    }
}
