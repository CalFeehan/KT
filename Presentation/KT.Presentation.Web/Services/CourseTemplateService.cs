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

    public async Task<CourseTemplateResponse> CourseTemplatesPOSTAsync(AddCourseTemplateRequest courseTemplate)
    {
        var client = new Client("http://localhost:5130", new HttpClient());
        var courseTemplateResponse = await client.CoursetemplatesPOSTAsync(courseTemplate);
        return courseTemplateResponse;
    }
}
