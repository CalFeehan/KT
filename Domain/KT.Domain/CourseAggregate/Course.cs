using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.CourseAggregate.Entities;
using KT.Domain.CourseAggregate.Events;

namespace KT.Domain.CourseAggregate;

public class Course : AggregateRoot
{
    // entities
    private readonly List<Module> _modules = [];
    public IReadOnlyList<Module> Modules => _modules.AsReadOnly();
    

    // value objects
    public Guid LearnerId { get; private set; }

    public CourseStatus CourseStatus { get; private set; }

    public string Code { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public int Level { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime ExpectedEndDate { get; private set; }

    public DateTime? ActualEndDate { get; private set; }


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

    public static Course Create(Guid learnerId, string code, string title, string description, int level, DateTime startDate, DateTime expectedEndDate, DateTime? actualEndDate)
    {
        var course = new Course(Guid.NewGuid(), learnerId, code, title, description, level, startDate, expectedEndDate, actualEndDate);

        course.AddDomainEvent(new CourseCreated(course));

        return course;
    }

    public Module AddModule(string title, string code, string description, int level, AwardingOrganisation awardingOrganisation)
    {
        var module = Module.Create(Id, title, code, description, level, awardingOrganisation);
        _modules.Add(module);

        AddDomainEvent(new ModuleAdded(Id, module));

        return module;
    }

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