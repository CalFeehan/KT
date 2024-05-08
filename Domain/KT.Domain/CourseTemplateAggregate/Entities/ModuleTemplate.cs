using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.CourseTemplateAggregate.ValueObjects;

namespace KT.Domain.CourseTemplateAggregate.Entities;

/// <summary>
/// A module template holds all of the details needed to create a module,
/// including its criteria.
/// </summary>
public class ModuleTemplate : Entity
{
    /// <summary>
    /// The course template that this module template belongs to.
    /// </summary>
    public Guid CourseTemplateId { get; private set; }

    /// <summary>
    /// The inner collection of criteria templates.
    /// Note: This is a private collection, so it can only be modified by the ModuleTemplate itself.
    /// </summary>
    private readonly List<CriteriaTemplate> _criteriaTemplates = [];

    /// <summary>
    /// The public accessor for the criteria templates.
    /// This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyCollection<CriteriaTemplate> CriteriaTemplates => _criteriaTemplates.AsReadOnly();

    /// <summary>
    /// The type of module. E.g., "NVQ", "Technical Certificate", "Essential Skills", etc.
    /// </summary>
    public ModuleType ModuleType { get; private set; }

    /// <summary>
    /// The title of the module template. E.g., "Introduction to Software Development"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// The description of the module template. E.g., "An introduction to software development concepts."
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// The code of the module template. E.g., "SD1-2024-INTRO"
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// The level of the module template. E.g., 1, 2, 3, etc.
    /// </summary>
    public int Level { get; private set; }

    /// <summary>
    /// The duration of the module template in weeks. E.g., 12 weeks.
    /// </summary>
    public int DurationInWeeks { get; private set; }

    /// <summary>
    /// Private constructor to ensure that the only way to create a module template is through the Create method.
    /// </summary>
    private ModuleTemplate(
        Guid id, Guid courseTemplateId, string title, string description, string code, int level, int durationInWeeks)
        : base(id)
    {
        CourseTemplateId = courseTemplateId;
        Title = title;
        Description = description;
        Code = code;
        Level = level;
        DurationInWeeks = durationInWeeks;
    }

    /// <summary>
    /// Creates a new module template.
    /// </summary>
    public static ModuleTemplate Create(
        Guid courseTemplateId, string title, string description, string code, int level, int durationInWeeks)
    {
        var ModuleTemplate = new ModuleTemplate(
            Guid.NewGuid(), courseTemplateId, title, description, code, level, durationInWeeks);

        return ModuleTemplate;
    }

    /// <summary>
    /// Adds a criteria template to the module template.
    /// </summary>
    public void AddCriteriaTemplate(CriteriaTemplate criteriaTemplate)
    {
        _criteriaTemplates.Add(criteriaTemplate);
    }

    /// <summary>
    /// Removes a criteria template from the module template.
    /// </summary>
    public void RemoveCriteriaTemplate(CriteriaTemplate criteriaTemplate)
    {
        _criteriaTemplates.Remove(criteriaTemplate);
    }
    
    
    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ModuleTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
