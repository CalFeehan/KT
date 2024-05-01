using KT.Domain.Common.Models;

namespace KT.Domain.LibraryAggregate.ValueObjects;

public class CriteriaTemplate : ValueObject
{
    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Code { get; private set; }

    public string CriteriaGroup { get; private set; }

    private CriteriaTemplate(string title, string description, string code, string criteriaGroup)
    {
        Title = title;
        Description = description;
        Code = code;
        CriteriaGroup = criteriaGroup;
    }

    public static CriteriaTemplate Create(string title, string description, string code, string criteriaGroup)
    {
        return new CriteriaTemplate(title, description, code, criteriaGroup);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Description;
        yield return Code;
        yield return CriteriaGroup;
    }
}
