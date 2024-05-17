using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public class CourseTemplateService : ICourseTemplateService
{
    private readonly IClient _client;

    public CourseTemplateService(IClient client)
    {
        _client = client;
    }

    public async Task<List<CourseTemplateResponse>> ListAsync()
    {
        var courseTemplates = await _client.CoursetemplatesAllAsync();
        return [.. courseTemplates];
    }

    public async Task<CourseTemplateResponse> GetByIdAsync(Guid id)
    {
        var courseTemplate = await _client.CoursetemplatesGETAsync(id);
        return courseTemplate;
    }

    public async Task<CourseTemplateResponse> AddAsync(AddCourseTemplateRequest courseTemplate)
    {
        var courseTemplateResponse = await _client.CoursetemplatesPOSTAsync(courseTemplate);
        return courseTemplateResponse;
    }
}