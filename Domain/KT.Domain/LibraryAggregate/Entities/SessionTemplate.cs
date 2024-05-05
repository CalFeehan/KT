using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.LibraryAggregate.ValueObjects;

namespace KT.Domain.LibraryAggregate.Entities;

public class SessionTemplate : Entity
{
    // parent id
    public Guid SessionPlanTemplateId { get; private set; }

    // entities

    // value objects
    public SessionType SessionType { get; private set; }

    public ScheduleDetails ScheduleDetails { get; private set; }

    public Guid? CohortId { get; private set; }

    public string Location { get; private set; } = string.Empty;

    public string Notes { get; private set; } = string.Empty;

    public string MeetingLink { get; private set; } = string.Empty;

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

    public static SessionTemplate Create(
        Guid sessionPlanTemplateId, SessionType sessionType, Guid? cohortId, string location, string notes, string meetingLink, 
        int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        var scheduleDetails = ScheduleDetails.Create(startWeek, dayOfWeek, startTime, expectedDuration);
        
        var sessionTemplate = new SessionTemplate(
            Guid.NewGuid(), sessionPlanTemplateId, sessionType, cohortId, location, notes, meetingLink, scheduleDetails);

        return sessionTemplate;
    }

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
