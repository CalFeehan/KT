using KT.Domain.Common.Models;

namespace KT.Domain;

public class ActivityPlanTemplate : Entity
{
    // parent id
    public Guid CourseTemplateId { get; private set; }

    // entities
    private readonly List<ActivityTemplate> _activityTemplates = [];
    public IReadOnlyCollection<ActivityTemplate> ActivityTemplates => _activityTemplates.AsReadOnly();

    private ActivityPlanTemplate(Guid id, Guid courseTemplateId) 
        : base(id)
    {
        CourseTemplateId = courseTemplateId;
    }

    public static ActivityPlanTemplate Create(Guid courseTemplateId)
    {
        var activityPlanTemplate = new ActivityPlanTemplate(Guid.NewGuid(), courseTemplateId);
        
        return activityPlanTemplate;
    }

    public void AddActivityTemplate(ActivityTemplate activityTemplate)
    {
        _activityTemplates.Add(activityTemplate);
    }

    public void RemoveActivityTemplate(ActivityTemplate activityTemplate)
    {
        _activityTemplates.Remove(activityTemplate);
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ActivityPlanTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
