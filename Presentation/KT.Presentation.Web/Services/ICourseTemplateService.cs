using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public interface ICourseTemplateService
{
    Task<List<CourseTemplateResponse>> ListAsync();

    Task<CourseTemplateResponse> GetByIdAsync(Guid id);

    Task<CourseTemplateResponse> AddAsync(AddCourseTemplateRequest courseTemplate);
}