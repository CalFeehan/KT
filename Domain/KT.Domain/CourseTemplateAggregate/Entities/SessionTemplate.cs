using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.CourseTemplateAggregate.ValueObjects;

namespace KT.Domain.CourseTemplateAggregate.Entities;

/// <summary>
/// A session template is used to define a specific session that will be part of a learning plan.
/// </summary>
public class SessionTemplate : Entity
{
    /// <summary>
    /// The session plan template that this session template belongs to.
    /// </summary>
    public Guid SessionPlanTemplateId { get; private set; }

    /// <summary>
    /// The type of session. E.g., "TeachingAndLearning", "Review", etc.
    public SessionType SessionType { get; private set; }

    /// <summary>
    /// The schedule details for the session template.
    /// This will be used to calculate session dates, etc. and populate the learning plan.
    /// </summary>
    public ScheduleDetails ScheduleDetails { get; private set; }

    /// <summary>
    /// The cohort that this session template belongs to.
    /// If a CohortId is given then this session will apply to all learners in that cohort.
    /// </summary>
    public Guid? CohortId { get; private set; }

    /// <summary>
    /// The location of the session. E.g., "Room 101", "Online", etc.
    /// </summary>
    public string Location { get; private set; } = string.Empty;

    /// <summary>
    /// Any notes for the session. E.g., "Please bring a pen and paper."
    /// </summary>
    public string Notes { get; private set; } = string.Empty;

    /// <summary>
    /// The meeting link for the session. E.g., "https://teams.microsoft.com/..."
    /// </summary>
    public string MeetingLink { get; private set; } = string.Empty;

    /// <summary>
    /// Private constructor to ensure that the only way to create a session template is through the Create method.
    /// </summary>
    private SessionTemplate(
        Guid id, Guid sessionPlanTemplateId, SessionType sessionType, Guid? cohortId, string location, string notes, string meetingLink, ScheduleDetails scheduleDetails)
        : base(id)
    {
        SessionPlanTemplateId = sessionPlanTemplateId;
        SessionType = sessionType;
        CohortId = cohortId;
        Location = location;
        Notes = notes;
        MeetingLink = meetingLink;
        ScheduleDetails = scheduleDetails;
    }

    /// <summary>
    /// Creates a new session template.
    /// </summary>
    public static SessionTemplate Create(
        Guid sessionPlanTemplateId, SessionType sessionType, Guid? cohortId, string location, string notes, string meetingLink, 
        int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        var scheduleDetails = ScheduleDetails.Create(startWeek, dayOfWeek, startTime, expectedDuration);
        
        var sessionTemplate = new SessionTemplate(
            Guid.NewGuid(), sessionPlanTemplateId, sessionType, cohortId, location, notes, meetingLink, scheduleDetails);

        return sessionTemplate;
    }

    /// <summary>
    /// Overwrites the schedule details for the session template.
    /// </summary>
    public ScheduleDetails ChangeScheduleDetails(int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        ScheduleDetails = ScheduleDetails.Create(startWeek, dayOfWeek, startTime, expectedDuration);
        return ScheduleDetails;
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private SessionTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
