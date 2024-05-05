using KT.Domain.Common.Models;

namespace KT.Domain.LibraryAggregate.ValueObjects;

public class ScheduleDetails : ValueObject
{
    public int StartWeek { get; private set; }

    public DayOfWeek DayOfWeek { get; private set; }

    public TimeOnly StartTime { get; private set; }

    public TimeSpan ExpectedDuration { get; private set; }

    private ScheduleDetails(int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        StartWeek = startWeek;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        ExpectedDuration = expectedDuration;
    }

    public static ScheduleDetails Create(int startWeek, DayOfWeek dayOfWeek, TimeOnly startTime, TimeSpan expectedDuration)
    {
        var scheduleDetails = new ScheduleDetails(startWeek, dayOfWeek, startTime, expectedDuration);

        return scheduleDetails;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartWeek;
        yield return DayOfWeek;
        yield return StartTime;
        yield return ExpectedDuration;
    }
}
