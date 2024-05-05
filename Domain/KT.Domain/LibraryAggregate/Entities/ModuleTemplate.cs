using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.LibraryAggregate.ValueObjects;

namespace KT.Domain.LibraryAggregate.Entities;

public class ModuleTemplate : Entity
{
    // parent id
    public Guid CourseTemplateId { get; private set; }

    // entities
    private readonly List<CriteriaTemplate> _criteriaTemplates = [];
    public IReadOnlyCollection<CriteriaTemplate> CriteriaTemplates => _criteriaTemplates.AsReadOnly();

    // value objects
    public ModuleType ModuleType { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Code { get; private set; }

    public int Level { get; private set; }

    public int DurationInWeeks { get; private set; }

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

    public static ModuleTemplate Create(
        Guid courseTemplateId, string title, string description, string code, int level, int durationInWeeks)
    {
        var ModuleTemplate = new ModuleTemplate(
            Guid.NewGuid(), courseTemplateId, title, description, code, level, durationInWeeks);

        return ModuleTemplate;
    }

    public void AddCriteriaTemplate(CriteriaTemplate criteriaTemplate)
    {
        _criteriaTemplates.Add(criteriaTemplate);
    }

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
