using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public class LibraryService : ILibraryService
{
    public async Task<List<LibraryResponse>> LibrariesAllAsync()
    {
        var client = new Client("http://localhost:5130", new HttpClient());
        var libraries = await client.LibrariesAllAsync();
        return [.. libraries];
    }
}
