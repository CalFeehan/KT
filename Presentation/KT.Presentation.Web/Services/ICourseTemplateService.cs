using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public interface ICourseTemplateService
{
    Task<List<CourseTemplateResponse>> CourseTemplatesAllAsync();
}