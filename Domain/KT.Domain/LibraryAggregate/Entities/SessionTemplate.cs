using System.ComponentModel.DataAnnotations.Schema;
using KT.Common.Enums;
using KT.Domain.Common.Models;

namespace KT.Domain.LibraryAggregate.Entities;

public class SessionTemplate : Entity
{
    // parent id
    public Guid SessionPlanTemplateId { get; private set; }

    // entities

    // value objects
    public SessionType SessionType { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime EndTime { get; private set; }

    public Guid? CohortId { get; private set; }

    public string Location { get; private set; } = string.Empty;

    public string Notes { get; private set; } = string.Empty;

    public string MeetingLink { get; private set; } = string.Empty;

    private SessionTemplate(
        Guid id, Guid sessionPlanTemplateId, SessionType sessionType, DateTime startTime, DateTime endTime, Guid? cohortId, string location, string notes, string meetingLink)
        : base(id)
    {
        SessionPlanTemplateId = sessionPlanTemplateId;
        SessionType = sessionType;
        StartTime = startTime;
        EndTime = endTime;
        CohortId = cohortId;
        Location = location;
        Notes = notes;
        MeetingLink = meetingLink;
    }

    public static SessionTemplate Create(
        Guid sessionPlanTemplateId, SessionType sessionType, DateTime startTime, DateTime endTime, Guid? cohortId, string location, string notes, string meetingLink)
    {
        var sessionTemplate = new SessionTemplate(
            Guid.NewGuid(), sessionPlanTemplateId, sessionType, startTime, endTime, cohortId, location, notes, meetingLink);

        return sessionTemplate;
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private SessionTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
