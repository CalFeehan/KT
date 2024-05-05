using KT.Domain.Common.Models;

namespace KT.Domain.CourseAggregate.ValueObjects;

/// <summary>
/// A criteria is a specific requirement that a learner must meet in order to pass a module.
/// </summary>
public class Criteria : ValueObject
{
    /// <summary>
    /// The title of the criteria. E.g., "Assignment 1"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// The description of the criteria. E.g., "Describe the history of computer science."
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// The code of the criteria. E.g., "CS-101-01"
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// The group that the criteria belongs to. E.g., "Assignments", "Exams", etc.
    /// </summary>
    public string CriteriaGroup { get; private set; }

    /// <summary>
    /// Private constructor to ensure that the only way to create a criteria is through the Create method.
    /// </summary>
    private Criteria(string title, string description, string code, string criteriaGroup)
    {
        Title = title;
        Description = description;
        Code = code;
        CriteriaGroup = criteriaGroup;
    }
    
    /// <summary>
    /// Creates a new criteria.
    /// </summary>
    public static Criteria Create(string title, string description, string code, string criteriaGroup)
    {
        return new Criteria(title, description, code, criteriaGroup);
    }

    /// <summary>
    /// Compares two criteria for equality.
    /// </summary>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Description;
        yield return Code;
        yield return CriteriaGroup;
    }
}
