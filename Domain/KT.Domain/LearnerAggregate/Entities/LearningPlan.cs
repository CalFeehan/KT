using KT.Domain.Common.Models;

namespace KT.Domain.LearnerAggregate.Entities;

/// <summary>
///     A learning plan is used to define a specific plan that a learner will follow.
///     It will track progress and completion of the plan.
/// </summary>
public class LearningPlan : Entity
{
    /// <summary>
    ///     Private constructor to ensure that the only way to create a learning plan is through the Create method.
    /// </summary>
    private LearningPlan(Guid id, Guid learnerId, string title, string description)
        : base(id)
    {
        LearnerId = learnerId;
        Title = title;
        Description = description;
    }


    #region EF Core Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private LearningPlan(Guid id) : base(id)
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    #endregion

    /// <summary>
    ///     The ID of the learner that this learning plan belongs to.
    /// </summary>
    public Guid LearnerId { get; private set; }

    /// <summary>
    ///     The title of the learning plan. E.g., "Software Development Plan"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    ///     The description of the learning plan. E.g., "This plan will cover the basics of software development."
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    ///     Creates a new learning plan.
    /// </summary>
    public static LearningPlan Create(Guid learnerId, string title, string description)
    {
        var learningPlan = new LearningPlan(Guid.NewGuid(), learnerId, title, description);

        return learningPlan;
    }
}