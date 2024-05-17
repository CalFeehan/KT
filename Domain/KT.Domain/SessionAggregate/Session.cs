using System.ComponentModel.DataAnnotations.Schema;
using KT.Common.Enums;
using KT.Domain.Common.Models;

namespace KT.Domain.SessionAggregate;

/// <summary>
///     A session is a single instance of a course session.
/// </summary>
public class Session : AggregateRoot
{
    /// <summary>
    ///     Private constructor to ensure that the only way to create a session is through the Create method.
    /// </summary>
    private Session(
        Guid id, Guid courseId, SessionType sessionType, DateTime startTime, DateTime endTime, Guid? cohortId,
        string location, string notes, string meetingLink)
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


    #region EF Core Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Session(Guid id) : base(id)
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    #endregion

    /// <summary>
    ///     The ID of the course that this session is a part of.
    /// </summary>
    public Guid CourseId { get; private set; }


    /// <summary>
    ///     The type of session. E.g., "TeachingandLearning", "Review", etc.
    /// </summary>
    public SessionType SessionType { get; private set; }

    /// <summary>
    ///     The start time of the session. E.g., "2022-01-01T09:00:00"
    /// </summary>
    public DateTime StartTime { get; }

    /// <summary>
    ///     The end time of the session. E.g., "2022-01-01T10:00:00"
    /// </summary>
    public DateTime EndTime { get; }

    /// <summary>
    ///     The duration of the session. E.g., "01:00:00"
    /// </summary>
    [NotMapped]
    public TimeSpan Duration => EndTime - StartTime;

    /// <summary>
    ///     The ID of the cohort that this session is a part of.
    ///     If a cohort ID is present, this session is a cohort session.
    /// </summary>
    public Guid? CohortId { get; }

    /// <summary>
    ///     A flag to determine if this session is a cohort session.
    /// </summary>
    [NotMapped]
    public bool IsCohortSession => CohortId.HasValue;

    /// <summary>
    ///     The location of the session. E.g., "Room 101", "Online", etc.
    /// </summary>
    public string Location { get; private set; } = string.Empty;

    /// <summary>
    ///     Any notes about the session. E.g., "Bring a pen and paper."
    /// </summary>
    public string Notes { get; private set; } = string.Empty;

    /// <summary>
    ///     The meeting link for the session. E.g., "https://zoom.us/1234567890"
    /// </summary>
    public string MeetingLink { get; private set; } = string.Empty;

    /// <summary>
    ///     Creates a new session.
    /// </summary>
    public static Session Create(
        Guid courseId, SessionType sessionType, DateTime startTime, DateTime endTime, Guid? cohortId, string location,
        string notes, string meetingLink)
    {
        var session = new Session(
            Guid.NewGuid(), courseId, sessionType, startTime, endTime, cohortId, location, notes, meetingLink);

        return session;
    }
}