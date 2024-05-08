using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.CourseAggregate.Entities;
using KT.Domain.CourseAggregate.Events;

namespace KT.Domain.CourseAggregate;

/// <summary>
/// A course is a collection of modules that a learner can study.
/// </summary>
public class Course : AggregateRoot
{
    /// <summary>
    /// The ID of the learner who is studying the course.
    /// </summary>
    public Guid LearnerId { get; private set; }

    /// <summary>
    /// The inner collection of modules.
    /// Note: This is a private collection, so it can only be modified by the Course itself.
    /// </summary>
    private readonly List<Module> _modules = [];

    /// <summary>
    /// The public accessor for the modules.
    /// This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyList<Module> Modules => _modules.AsReadOnly();
    
    /// <summary>
    /// The status of the course. E.g., "Not Started", "In Progress", "Completed", etc.
    /// </summary>
    public CourseStatus CourseStatus { get; private set; }

    /// <summary>
    /// The code of the course. E.g., "CS-101"
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// The title of the course. E.g., "Computer Science 101"
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// The description of the course. E.g., "This course will cover the basics of computer science."
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// The level of the course. E.g., 1, 2, 3, etc.
    /// </summary>
    public int Level { get; private set; }

    /// <summary>
    /// The start date of the course. E.g., "2022-01-01"
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// The expected end date of the course. E.g., "2022-12-31"
    /// </summary>
    public DateTime ExpectedEndDate { get; private set; }

    /// <summary>
    /// The actual end date of the course. E.g., "2022-12-31"
    /// </summary>
    public DateTime? ActualEndDate { get; private set; }


    /// <summary>
    /// Private constructor to ensure that the only way to create a course is through the Create method.
    /// </summary>
    private Course(Guid id, Guid learnerId, string code, string title, string description, int level, DateTime startDate, DateTime expectedEndDate, DateTime? actualEndDate)
        : base(id)
    {
        LearnerId = learnerId;
        CourseStatus = CourseStatus.NotStarted;
        Code = code;
        Title = title;
        Description = description;
        Level = level;
    }

    /// <summary>
    /// Creates a new course.
    /// </summary>
    public static Course Create(Guid learnerId, string code, string title, string description, int level, DateTime startDate, DateTime expectedEndDate, DateTime? actualEndDate)
    {
        var course = new Course(Guid.NewGuid(), learnerId, code, title, description, level, startDate, expectedEndDate, actualEndDate);

        course.AddDomainEvent(new CourseAdded(course));

        return course;
    }

    /// <summary>
    /// Adds a module to the course.
    /// </summary>
    public Module AddModule(string title, string code, string description, int level, AwardingOrganisation awardingOrganisation)
    {
        var module = Module.Create(Id, title, code, description, level, awardingOrganisation);
        _modules.Add(module);

        AddDomainEvent(new ModuleAdded(Id, module));

        return module;
    }

    /// <summary>
    /// Removes a module from the course.
    /// </summary>
    public void RemoveModule(Guid moduleId)
    {
        var module = _modules.FirstOrDefault(q => q.Id == moduleId) 
            ?? throw new InvalidOperationException($"Module with ID {moduleId} not found.");
        
        _modules.Remove(module);

        AddDomainEvent(new ModuleRemoved(Id, module));
    }

    

    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Course(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}