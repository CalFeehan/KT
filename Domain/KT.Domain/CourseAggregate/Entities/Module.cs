using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.CourseAggregate.ValueObjects;

namespace KT.Domain.CourseAggregate.Entities;

public class Module : Entity
{
    // parent id
    public Guid CourseId { get; private set; }
    

    // entities
    private readonly List<Criteria> _criteria = [];
    public IReadOnlyList<Criteria> Criteria => _criteria.AsReadOnly();


    // value objects
    public ModuleStatus ModuleStatus { get; private set; }

    public string Code { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public int Level { get; private set; }

    public AwardingOrganisation AwardingOrganisation { get; private set; }
    

    private Module(Guid id, Guid courseId, string code, string title, string description, int level, AwardingOrganisation awardingOrganisation)
     : base(id)
    {
        CourseId = courseId;
        Code = code;
        Title = title;
        Description = description;
        Level = level;
        AwardingOrganisation = awardingOrganisation;
    }


    public static Module Create(
        Guid courseId, string code, string title, string description, int level, AwardingOrganisation awardingOrganisation)
    {
        var module = new Module(Guid.NewGuid(), courseId, code, title, description, level, awardingOrganisation);

        return module;
    }

    public Criteria AddCriteria(string title, string description, string code, string criteriaGroup)
    {
        var criteria = ValueObjects.Criteria.Create(title, description, code, criteriaGroup);
        _criteria.Add(criteria);

        return criteria;
    }
    
    public void RemoveCriteria(Criteria criteria)
    {
        var found = _criteria.FirstOrDefault(x => x.Equals(criteria))
            ?? throw new InvalidOperationException($"Criteria not found.");
        
        _criteria.Remove(criteria);
    }

    
    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Module(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}