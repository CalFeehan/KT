using System.Text.Json.Serialization;
using KT.Domain.Common.Models;

namespace KT.Domain.LearnerAggregate.Entities;

public class LearningPlan : Entity
{
    public Guid LearnerId { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateOnly StartDate { get; private set; }

    public DateOnly ExpectedEndDate { get; private set; }

    [JsonConstructor]
    private LearningPlan(Guid id, Guid learnerId, string title, string description, DateOnly startDate, DateOnly expectedEndDate)
        : base(id)
    {
        LearnerId = learnerId;
        Title = title;
        Description = description;
        StartDate = startDate;
        ExpectedEndDate = expectedEndDate;
    }

    public static LearningPlan Create(Guid learnerId, string title, string description, DateOnly startDate, DateOnly expectedEndDate)
    {
        return new LearningPlan(Guid.NewGuid(), learnerId, title, description, startDate, expectedEndDate);
    }
}
