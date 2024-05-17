using KT.Domain.Common.Models;

namespace KT.Domain.CourseTemplateAggregate.Entities;

/// <summary>
///     An activity plan template holds all of the details needed to create a series of activities,
///     including all details of those activities.
/// </summary>
public class ActivityPlanTemplate : Entity
{
    /// <summary>
    ///     The inner collection of activity templates.
    ///     Note: This is a private collection, so it can only be modified by the ActivityPlanTemplate itself.
    /// </summary>
    private readonly List<ActivityTemplate> _activityTemplates = [];

    /// <summary>
    ///     Private constructor to ensure that the only way to create an activity plan template is through the Create method.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="courseTemplateId"></param>
    private ActivityPlanTemplate(Guid id, Guid courseTemplateId)
        : base(id)
    {
        CourseTemplateId = courseTemplateId;
    }


    #region EF Core Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ActivityPlanTemplate(Guid id) : base(id)
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    #endregion

    /// <summary>
    ///     The course template that this activity plan template belongs to.
    /// </summary>
    public Guid CourseTemplateId { get; private set; }

    /// <summary>
    ///     The public accessor for the activity templates.
    ///     This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyCollection<ActivityTemplate> ActivityTemplates => _activityTemplates.AsReadOnly();

    /// <summary>
    ///     Creates a new activity plan template.
    ///     This should only be used once per course template.
    /// </summary>
    public static ActivityPlanTemplate Create(Guid courseTemplateId)
    {
        var activityPlanTemplate = new ActivityPlanTemplate(Guid.NewGuid(), courseTemplateId);

        return activityPlanTemplate;
    }

    /// <summary>
    ///     Adds an activity template to the activity plan template.
    /// </summary>
    public void AddActivityTemplate(ActivityTemplate activityTemplate)
    {
        _activityTemplates.Add(activityTemplate);
    }

    /// <summary>
    ///     Removes an activity template from the activity plan template.
    /// </summary>
    public void RemoveActivityTemplate(ActivityTemplate activityTemplate)
    {
        _activityTemplates.Remove(activityTemplate);
    }
}