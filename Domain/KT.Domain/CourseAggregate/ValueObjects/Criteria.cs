using KT.Domain.Common.Models;

namespace KT.Domain.CourseAggregate.ValueObjects;

public class Criteria : ValueObject
{
    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Code { get; private set; }

    public string CriteriaGroup { get; private set; }

    private Criteria(string title, string description, string code, string criteriaGroup)
    {
        Title = title;
        Description = description;
        Code = code;
        CriteriaGroup = criteriaGroup;
    }

    public static Criteria Create(string title, string description, string code, string criteriaGroup)
    {
        return new Criteria(title, description, code, criteriaGroup);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Description;
        yield return Code;
        yield return CriteriaGroup;
    }
}
