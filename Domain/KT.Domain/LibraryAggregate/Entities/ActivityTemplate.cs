using KT.Domain.Common.Models;

namespace KT.Domain.LibraryAggregate.Entities;

public class ActivityTemplate : Entity
{
    // parent id
    public Guid ActivityPlanTemplateId { get; private set; }

    // value objects
    public string Title { get; private set; }

    public string Description { get; private set; }

    public TimeSpan Duration { get; private set; }

    public List<Guid> DocumentIds { get; private set; }

    public List<Guid> ModuleTemplateIds { get; private set; }

    private ActivityTemplate(Guid id, Guid activityPlanTemplateId, string title, string description, TimeSpan duration, List<Guid> documentIds, List<Guid> moduleTemplateIds) 
        : base(id)
    {
        ActivityPlanTemplateId = activityPlanTemplateId;
        Title = title;
        Description = description;
        Duration = duration;
        DocumentIds = documentIds;
        ModuleTemplateIds = moduleTemplateIds;
    }

    public static ActivityTemplate Create(
        Guid activityPlanTemplateId, string title, string description, TimeSpan duration, List<Guid> documentIds, List<Guid> moduleTemplateIds)
    {
        var activityTemplate = new ActivityTemplate(Guid.NewGuid(), activityPlanTemplateId, title, description, duration, documentIds, moduleTemplateIds);
        
        return activityTemplate;
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ActivityTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
