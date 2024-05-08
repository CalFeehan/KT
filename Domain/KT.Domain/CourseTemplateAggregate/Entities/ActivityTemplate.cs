using KT.Domain.Common.Models;
using KT.Domain.CourseTemplateAggregate.ValueObjects;

namespace KT.Domain.CourseTemplateAggregate.Entities;

/// <summary>
/// An activity template is used to define a specific activity that will be part of a learning plan.
/// </summary>
public class ActivityTemplate : Entity
{
    /// <summary>
    /// The activity plan template that this activity template belongs to.
    /// </summary>
    public Guid ActivityPlanTemplateId { get; private set; }

    /// <summary>
    /// The title of the activity template. E.g., "Introduction to Software Development Booklet"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// The description of the activity template. E.g., "A booklet covering an introduction to software development concepts."
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// The list of document IDs associated with the activity template.
    /// </summary>
    public List<Guid> DocumentIds { get; private set; }

    /// <summary>
    /// The list of module template IDs associated with the activity template.
    /// </summary>
    public List<Guid> ModuleTemplateIds { get; private set; }

    /// <summary>
    /// The schedule details for the activity template.
    /// This will be used to calculate activity dates, etc. and populate the learning plan.
    /// </summary>
    public ScheduleDetails ScheduleDetails { get; private set; }

    /// <summary>
    /// Private constructor to ensure that the only way to create an activity template is through the Create method.
    /// </summary>
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

    /// <summary>
    /// Creates a new activity template.
    /// </summary>
    public static ActivityTemplate Create(
        Guid activityPlanTemplateId, string title, string description, List<Guid> documentIds, List<Guid> moduleTemplateIds,
        int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        var scheduleDetails = ScheduleDetails.Create(startWeek, dayOfWeek, startTime, expectedDuration);

        var activityTemplate = new ActivityTemplate(
            Guid.NewGuid(), activityPlanTemplateId, title, description, documentIds, moduleTemplateIds, scheduleDetails);
        
        return activityTemplate;
    }

    /// <summary>
    /// Overwrites the schedule details for the activity template.
    /// </summary>
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
