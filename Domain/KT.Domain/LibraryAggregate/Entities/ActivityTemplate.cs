using KT.Domain.Common.Models;
using KT.Domain.LibraryAggregate.ValueObjects;

namespace KT.Domain.LibraryAggregate.Entities;

public class ActivityTemplate : Entity
{
    // parent id
    public Guid ActivityPlanTemplateId { get; private set; }


    // value objects
    public string Title { get; private set; }

    public string Description { get; private set; }

    public List<Guid> DocumentIds { get; private set; }

    public List<Guid> ModuleTemplateIds { get; private set; }

    public ScheduleDetails ScheduleDetails { get; private set; }


    private ActivityTemplate(
        Guid id, Guid activityPlanTemplateId, string title, string description, List<Guid> documentIds, List<Guid> moduleTemplateIds,
        ScheduleDetails scheduleDetails) 
        : base(id)
    {
        ActivityPlanTemplateId = activityPlanTemplateId;
        Title = title;
        Description = description;
        DocumentIds = documentIds;
        ModuleTemplateIds = moduleTemplateIds;
        ScheduleDetails = scheduleDetails;
    }

    public static ActivityTemplate Create(
        Guid activityPlanTemplateId, string title, string description, List<Guid> documentIds, List<Guid> moduleTemplateIds,
        int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        var scheduleDetails = ScheduleDetails.Create(startWeek, dayOfWeek, startTime, expectedDuration);

        var activityTemplate = new ActivityTemplate(
            Guid.NewGuid(), activityPlanTemplateId, title, description, documentIds, moduleTemplateIds, scheduleDetails);
        
        return activityTemplate;
    }

    public ScheduleDetails ChangeScheduleDetails(int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        ScheduleDetails = ScheduleDetails.Create(startWeek, dayOfWeek, startTime, expectedDuration);
        return ScheduleDetails;
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ActivityTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
