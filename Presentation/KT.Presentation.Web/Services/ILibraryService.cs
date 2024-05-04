using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public interface ILibraryService
{
    Task<List<LibraryResponse>> LibrariesAllAsync();
}