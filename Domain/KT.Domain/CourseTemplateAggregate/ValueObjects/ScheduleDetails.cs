using KT.Domain.Common.Models;

namespace KT.Domain.CourseTemplateAggregate.ValueObjects;

/// <summary>
///     The schedule details for a session template.
///     This will be used to calculate session dates, etc. and populate the learning plan.
/// </summary>
public class ScheduleDetails : ValueObject
{
    /// <summary>
    ///     Private constructor to ensure that the only way to create a ScheduleDetails object is through the Create method.
    /// </summary>
    private ScheduleDetails(int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        StartWeek = startWeek;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        ExpectedDuration = expectedDuration;
    }

    /// <summary>
    ///     The week that the session starts in. E.g., 1, 2, 3, etc.
    /// </summary>
    public int StartWeek { get; }

    /// <summary>
    ///     The day of the week that the session is on. E.g., Monday, Tuesday, Wednesday, etc.
    /// </summary>
    public DayOfWeek DayOfWeek { get; }

    /// <summary>
    ///     The time that the session starts at. E.g., 09:00, 13:30, etc.
    /// </summary>
    public TimeOnly StartTime { get; }

    /// <summary>
    ///     The expected duration of the session. E.g., 1 hour, 2 hours, etc.
    /// </summary>
    public TimeSpan ExpectedDuration { get; }

    /// <summary>
    ///     Creates a new ScheduleDetails object.
    /// </summary>
    public static ScheduleDetails Create(int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime,
        TimeSpan expectedDuration)
    {
        var scheduleDetails = new ScheduleDetails(startWeek, dayOfWeek, startTime, expectedDuration);

        return scheduleDetails;
    }

    /// <summary>
    ///     Compares two ScheduleDetails objects for equality.
    /// </summary>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartWeek;
        yield return DayOfWeek;
        yield return StartTime;
        yield return ExpectedDuration;
    }
}