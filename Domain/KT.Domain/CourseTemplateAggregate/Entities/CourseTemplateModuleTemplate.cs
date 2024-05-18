using KT.Domain.Common.Models;

namespace KT.Domain.CourseTemplateAggregate.Entities;

public class CourseTemplateModuleTemplate : Entity
{
    private CourseTemplateModuleTemplate(Guid id, Guid courseTemplateId, Guid moduleTemplateId) : base(id)
    {
        CourseTemplateId = courseTemplateId;
        ModuleTemplateId = moduleTemplateId;
    }

    #region EF Core Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CourseTemplateModuleTemplate(Guid id) : base(id)
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    #endregion

    public Guid CourseTemplateId { get; }

    public Guid ModuleTemplateId { get; }

    public static CourseTemplateModuleTemplate Create(Guid courseTemplateId, Guid moduleTemplateId)
    {
        var courseTemplateModuleTemplate = new CourseTemplateModuleTemplate(
            Guid.NewGuid(), courseTemplateId, moduleTemplateId);

        return courseTemplateModuleTemplate;
    }
}