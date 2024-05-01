using System.ComponentModel.DataAnnotations.Schema;
using KT.Common.Enums;
using KT.Domain.Common.Models;

namespace KT.Domain.SessionAggregate;

public class Session : AggregateRoot
{
    // entities
    public Guid CourseId { get; private set; }


    // value objects
    public SessionType SessionType { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime EndTime { get; private set; }

    [NotMapped]
    public TimeSpan Duration => EndTime - StartTime;

    public Guid? CohortId { get; private set; }

    [NotMapped]
    public bool IsCohortSession => CohortId.HasValue;

    public string Location { get; private set; } = string.Empty;

    public string Notes { get; private set; } = string.Empty;

    public string MeetingLink { get; private set; } = string.Empty;

    private Session(
        Guid id, Guid courseId, SessionType sessionType, DateTime startTime, DateTime endTime, Guid? cohortId, string location, string notes, string meetingLink)
        : base(id)
    {
        CourseId = courseId;
        SessionType = sessionType;
        StartTime = startTime;
        EndTime = endTime;
        CohortId = cohortId;
        Location = location;
        Notes = notes;
        MeetingLink = meetingLink;
    }

    public static Session Create(
        Guid courseId, SessionType sessionType, DateTime startTime, DateTime endTime, Guid? cohortId, string location, string notes, string meetingLink)
    {
        var session = new Session(
            Guid.NewGuid(), courseId, sessionType, startTime, endTime, cohortId, location, notes, meetingLink);

        return session;
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Session(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
