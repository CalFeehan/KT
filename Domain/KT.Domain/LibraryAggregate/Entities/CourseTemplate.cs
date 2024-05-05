using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.LibraryAggregate.Events;

namespace KT.Domain.LibraryAggregate.Entities;

/// <summary>
/// A course template holds all of the details needed to create a course, 
/// including its modules, sessions and activities. 
/// It will be used to calculate session dates, etc. and populate the learning plan.
public class CourseTemplate : Entity
{
    /// <summary>
    /// The library that this course template belongs to.
    /// </summary>
    public Guid LibraryId { get; private set; }


    /// <summary>
    /// The inner collection of module templates.
    /// Note: This is a private collection, so it can only be modified by the CourseTemplate itself.
    /// </summary>
    private readonly List<ModuleTemplate> _moduleTemplates = [];

    /// <summary>
    /// The public accessor for the module templates.
    /// This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyCollection<ModuleTemplate> ModuleTemplates => _moduleTemplates.AsReadOnly();

    /// <summary>
    /// The activity plan template for this course template.
    /// This will be used to calculate activity dates, etc. and populate the learning plan.
    /// </summary>
    public ActivityPlanTemplate ActivityPlanTemplate { get; private set; }

    /// <summary>
    /// The session plan template for this course template.
    /// This will be used to calculate session dates, etc. and populate the learning plan.
    /// </summary>
    public SessionPlanTemplate SessionPlanTemplate { get; private set; }

    /// <summary>
    /// The status of the course template. E.g., Draft, Published, Active.
    /// </summary>
    public CourseTemplateStatus CourseTemplateStatus { get; private set; }

    /// <summary>
    /// The title of the course template. E.g., "Software Development Level 1"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// The description of the course template. E.g., "Software Development Level 1 2024"
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// The code of the course template. E.g., "SD1-2024"
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// The level of the course template. E.g., 1
    /// </summary>
    public int Level { get; private set; }

    /// <summary>
    /// The duration of the course template in weeks. E.g., 52
    /// </summary>
    public int DurationInWeeks { get; private set; }
    
    /// <summary>
    /// Private constructor to ensure that the only way to create a course template is through the Create method.
    /// </summary>
    private CourseTemplate(Guid id, Guid libraryId, string title, string description, string code, int level, int durationInWeeks) 
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
        DurationInWeeks = durationInWeeks;
    }


    /// <summary>
    /// Creates a new course template.
    /// </summary>
    public static CourseTemplate Create(Guid libraryId, string title, string description, string code, int level, int durationInWeeks)
    {
        var courseTemplate = new CourseTemplate(Guid.NewGuid(), libraryId, title, description, code, level, durationInWeeks);

        courseTemplate.AddDomainEvent(new CourseTemplateCreated(courseTemplate));

        return courseTemplate;
    }

    /// <summary>
    /// Adds a module template to the course template.
    /// </summary>
    public void AddModuleTemplate(ModuleTemplate moduleTemplate)
    {
        _moduleTemplates.Add(moduleTemplate);
    }

    /// <summary>
    /// Removes a module template from the course template.
    /// </summary>
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