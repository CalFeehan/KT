using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public class CourseTemplateService : ICourseTemplateService
{
    public async Task<List<CourseTemplateResponse>> CourseTemplatesAllAsync()
    {
        var client = new Client("http://localhost:5130", new HttpClient());
        var courseTemplates = await client.CoursetemplatesAllAsync();
        return [.. courseTemplates];
    }
}
