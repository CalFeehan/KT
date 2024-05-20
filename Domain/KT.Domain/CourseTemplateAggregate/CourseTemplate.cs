using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.CourseTemplateAggregate.Entities;

namespace KT.Domain.CourseTemplateAggregate;

/// <summary>
///     A course template holds all the details needed to create a course,
///     including sessions, activities and linked modules.
///     It will be used to calculate session dates, etc. and populate the learning plan.
/// </summary>
public class CourseTemplate : AggregateRoot
{
    /// <summary>
    ///     Private constructor to ensure that the only way to create a course template is through the Create method.
    /// </summary>
    private CourseTemplate(Guid id, string title, string description, string code, int level, int durationInWeeks)
        : base(id)
    {
        SessionPlanTemplate = SessionPlanTemplate.Create(id);
        ActivityPlanTemplate = ActivityPlanTemplate.Create(id);
        CourseTemplateStatus = CourseTemplateStatus.Draft;
        Title = title;
        Description = description;
        Code = code;
        Level = level;
        DurationInWeeks = durationInWeeks;
    }


    #region EF Core Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CourseTemplate(Guid id) : base(id)
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    #endregion

    public List<CourseTemplateModuleTemplate> CourseTemplateModuleTemplates { get; } = [];

    /// <summary>
    ///     The activity plan template for this course template.
    ///     This will be used to calculate activity dates, etc. and populate the learning plan.
    /// </summary>
    public ActivityPlanTemplate ActivityPlanTemplate { get; private set; }

    /// <summary>
    ///     The session plan template for this course template.
    ///     This will be used to calculate session dates, etc. and populate the learning plan.
    /// </summary>
    public SessionPlanTemplate SessionPlanTemplate { get; private set; }

    /// <summary>
    ///     The status of the course template. E.g., Draft, Published, Active.
    /// </summary>
    public CourseTemplateStatus CourseTemplateStatus { get; private set; }

    /// <summary>
    ///     The title of the course template. E.g., "Software Development Level 1"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    ///     The description of the course template. E.g., "Software Development Level 1 2024"
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    ///     The code of the course template. E.g., "SD1-2024"
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    ///     The level of the course template. E.g., 1
    /// </summary>
    public int Level { get; private set; }

    /// <summary>
    ///     The duration of the course template in weeks. E.g., 52
    /// </summary>
    public int DurationInWeeks { get; private set; }


    /// <summary>
    ///     Creates a new course template.
    /// </summary>
    public static CourseTemplate Create(string title, string description, string code, int level, int durationInWeeks)
    {
        var courseTemplate = new CourseTemplate(Guid.NewGuid(), title, description, code, level, durationInWeeks);

        return courseTemplate;
    }

    /// <summary>
    ///     Updates the course template status.
    /// </summary>
    public void UpdateCourseTemplateStatus(CourseTemplateStatus courseTemplateStatus)
    {
        CourseTemplateStatus = courseTemplateStatus;
    }

    /// <summary>
    ///     Updates the basic details of the course template.
    /// </summary>
    public void UpdateBasicDetails(CourseTemplateStatus courseTemplateStatus, string title, string description,
        string code, int level, int durationInWeeks)
    {
        CourseTemplateStatus = courseTemplateStatus;
        Title = title;
        Description = description;
        Code = code;
        Level = level;
        DurationInWeeks = durationInWeeks;
    }

    /// <summary>
    ///     Updates the activity plan template for the course template.
    /// </summary>
    public void UpdateActivityPlanTemplate(ActivityPlanTemplate activityPlanTemplate)
    {
        ActivityPlanTemplate = activityPlanTemplate;
    }

    /// <summary>
    ///     Updates the session plan template for the course template.
    /// </summary>
    public void UpdateSessionPlanTemplate(SessionPlanTemplate sessionPlanTemplate)
    {
        SessionPlanTemplate = sessionPlanTemplate;
    }

    /// <summary>
    ///     Adds a module template to the course template.
    /// </summary>
    public void AddModuleTemplate(Guid moduleTemplateId)
    {
        var courseTemplateModuleTemplate = CourseTemplateModuleTemplate.Create(Id, moduleTemplateId);
        CourseTemplateModuleTemplates.Add(courseTemplateModuleTemplate);
    }

    /// <summary>
    ///     Removes a module template from the course template.
    /// </summary>
    public void RemoveModuleTemplate(Guid moduleTemplateId)
    {
        var courseTemplateModuleTemplate =
            CourseTemplateModuleTemplates.FirstOrDefault(x => x.ModuleTemplateId == moduleTemplateId);
        if (courseTemplateModuleTemplate is not null)
            CourseTemplateModuleTemplates.Remove(courseTemplateModuleTemplate);
    }

    /// <summary>
    ///     Updates the Module Templates for the course template.
    /// </summary>
    public void UpdateModuleTemplates(List<Guid> moduleTemplateIds)
    {
        var moduleTemplatesToRemove = CourseTemplateModuleTemplates
            .Where(x => !moduleTemplateIds.Contains(x.ModuleTemplateId))
            .Select(x => x.ModuleTemplateId)
            .ToList();

        var moduleTemplatesToAdd = moduleTemplateIds
            .Where(x => CourseTemplateModuleTemplates.All(y => y.ModuleTemplateId != x))
            .ToList();

        foreach (var moduleTemplateId in moduleTemplatesToRemove) RemoveModuleTemplate(moduleTemplateId);

        foreach (var moduleTemplateId in moduleTemplatesToAdd) AddModuleTemplate(moduleTemplateId);
    }
}