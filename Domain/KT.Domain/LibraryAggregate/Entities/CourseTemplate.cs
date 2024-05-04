using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.LibraryAggregate.Events;

namespace KT.Domain.LibraryAggregate.Entities;

public class CourseTemplate : Entity
{
    // parent id
    public Guid LibraryId { get; private set; }


    // entities
    private readonly List<ModuleTemplate> _moduleTemplates = [];
    public IReadOnlyCollection<ModuleTemplate> ModuleTemplates => _moduleTemplates.AsReadOnly();

    public ActivityPlanTemplate ActivityPlanTemplate { get; private set; }

    public SessionPlanTemplate SessionPlanTemplate { get; private set; }


    // value objects
    public CourseTemplateStatus CourseTemplateStatus { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Code { get; private set; }

    public int Level { get; private set; }
    
    
    private CourseTemplate(Guid id, Guid libraryId, string title, string description, string code, int level) 
        : base(id)
    {
        LibraryId = libraryId;
        SessionPlanTemplate = SessionPlanTemplate.Create(id);
        ActivityPlanTemplate = ActivityPlanTemplate.Create(id);
        CourseTemplateStatus = CourseTemplateStatus.Draft;
        Title = title;
        Description = description;
        Code = code;
        Level = level;
    }


    public static CourseTemplate Create(Guid libraryId, string title, string description, string code, int level)
    {
        var courseTemplate = new CourseTemplate(Guid.NewGuid(), libraryId, title, description, code, level);

        courseTemplate.AddDomainEvent(new CourseTemplateCreated(courseTemplate));

        return courseTemplate;
    }

    public void AddModuleTemplate(ModuleTemplate moduleTemplate)
    {
        _moduleTemplates.Add(moduleTemplate);
    }

    public void RemoveModuleTemplate(ModuleTemplate moduleTemplate)
    {
        _moduleTemplates.Remove(moduleTemplate);
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CourseTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}