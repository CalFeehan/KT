using KT.Domain.Common.Models;

namespace KT.Domain.CourseTemplateAggregate.ValueObjects;

public class CourseTemplateModuleTemplate : ValueObject
{
    private CourseTemplateModuleTemplate(Guid courseTemplateId, Guid moduleTemplateId)
    {
        CourseTemplateId = courseTemplateId;
        ModuleTemplateId = moduleTemplateId;
    }

    public Guid CourseTemplateId { get; }

    public Guid ModuleTemplateId { get; }

    public static CourseTemplateModuleTemplate Create(Guid courseTemplateId, Guid moduleTemplateId)
    {
        var courseTemplateModuleTemplate = new CourseTemplateModuleTemplate(courseTemplateId, moduleTemplateId);

        return courseTemplateModuleTemplate;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return CourseTemplateId;
        yield return ModuleTemplateId;
    }
}