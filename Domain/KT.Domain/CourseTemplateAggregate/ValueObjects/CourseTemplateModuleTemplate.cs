using KT.Domain.Common.Models;

namespace KT.Domain.CourseTemplateAggregate.ValueObjects;

public class CourseTemplateModuleTemplate : ValueObject
{
    public Guid CourseTemplateId { get; private set; }

    public Guid ModuleTemplateId { get; private set; }

    private CourseTemplateModuleTemplate(Guid courseTemplateId, Guid moduleTemplateId)
    {
        CourseTemplateId = courseTemplateId;
        ModuleTemplateId = moduleTemplateId;
    }

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