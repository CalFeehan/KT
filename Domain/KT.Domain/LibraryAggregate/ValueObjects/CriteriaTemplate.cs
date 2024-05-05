using KT.Domain.Common.Models;

namespace KT.Domain.LibraryAggregate.ValueObjects;

/// <summary>
/// A criteria template is used to define a specific criteria that will be part of a learning plan.
/// </summary>
public class CriteriaTemplate : ValueObject
{
    /// <summary>
    /// The title of the criteria template. E.g., "Object-Oriented Programming Concepts"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// The description of the criteria template. E.g., "Understand the difference between a class and an object."
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// The code of the criteria template. E.g., "OOP-101"
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// The group that the criteria template belongs to. E.g., "Programming Concepts", "Software Development", etc.
    /// </summary>
    public string CriteriaGroup { get; private set; }

    /// <summary>
    /// Private constructor to ensure that the only way to create a criteria template is through the Create method.
    /// </summary>
    private CriteriaTemplate(string title, string description, string code, string criteriaGroup)
    {
        Title = title;
        Description = description;
        Code = code;
        CriteriaGroup = criteriaGroup;
    }

    /// <summary>
    /// Creates a new criteria template.
    /// </summary>
    public static CriteriaTemplate Create(string title, string description, string code, string criteriaGroup)
    {
        return new CriteriaTemplate(title, description, code, criteriaGroup);
    }

    /// <summary>
    /// Compares two CriteriaTemplate objects for equality.
    /// </summary>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Description;
        yield return Code;
        yield return CriteriaGroup;
    }
}
