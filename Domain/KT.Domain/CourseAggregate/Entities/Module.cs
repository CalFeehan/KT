using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.CourseAggregate.ValueObjects;

namespace KT.Domain.CourseAggregate.Entities;

/// <summary>
/// A module is a collection of criteria that a learner must complete in order to pass the module.
/// </summary>
public class Module : Entity
{
    /// <summary>
    /// The ID of the course that the module belongs to.
    /// </summary>
    public Guid CourseId { get; private set; }
    

    /// <summary>
    /// The inner collection of criteria.
    /// Note: This is a private collection, so it can only be modified by the Module itself.
    /// </summary>
    private readonly List<Criteria> _criteria = [];

    /// <summary>
    /// The public accessor for the criteria.
    /// This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyList<Criteria> Criteria => _criteria.AsReadOnly();


    /// <summary>
    /// The status of the module. E.g., "Not Started", "In Progress", "Completed", etc.
    /// </summary>
    public ModuleStatus ModuleStatus { get; private set; }

    /// <summary>
    /// The code of the module. E.g., "CS-101"
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// The title of the module. E.g., "Computer Science 101"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// The description of the module. E.g., "This module will cover the basics of computer science."
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// The level of the module. E.g., 1, 2, 3, etc.
    /// </summary>
    public int Level { get; private set; }

    /// <summary>
    /// The awarding organisation of the module. E.g., "Pearson", "AQA", etc.
    /// </summary>
    public AwardingOrganisation AwardingOrganisation { get; private set; }
    
    /// <summary>
    /// Private constructor to ensure that the only way to create a module is through the Create method.
    /// </summary>
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

    /// <summary>
    /// Creates a new module.
    /// </summary>
    public static Module Create(
        Guid courseId, string code, string title, string description, int level, AwardingOrganisation awardingOrganisation)
    {
        var module = new Module(Guid.NewGuid(), courseId, code, title, description, level, awardingOrganisation);

        return module;
    }

    /// <summary>
    /// Adds a criteria to the module.
    /// </summary>
    public Criteria AddCriteria(string title, string description, string code, string criteriaGroup)
    {
        var criteria = ValueObjects.Criteria.Create(title, description, code, criteriaGroup);
        _criteria.Add(criteria);

        return criteria;
    }
    
    /// <summary>
    /// Removes a criteria from the module.
    /// </summary>
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