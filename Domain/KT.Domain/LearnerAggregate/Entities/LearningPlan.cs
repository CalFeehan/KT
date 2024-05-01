using System.Text.Json.Serialization;
using KT.Domain.Common.Models;

namespace KT.Domain.LearnerAggregate.Entities;

public class LearningPlan : Entity
{
    // parent id
    public Guid LearnerId { get; private set; }

    // entities

    // value objects
    public string Title { get; private set; }

    public string Description { get; private set; }


    private LearningPlan(Guid id, Guid learnerId, string title, string description)
        : base(id)
    {
        LearnerId = learnerId;
        Title = title;
        Description = description;
    }


    public static LearningPlan Create(Guid learnerId, string title, string description)
    {
        var learningPlan = new LearningPlan(Guid.NewGuid(), learnerId, title, description);

        return learningPlan;
    }
    

    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private LearningPlan(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
