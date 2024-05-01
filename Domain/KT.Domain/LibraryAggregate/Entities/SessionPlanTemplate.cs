using KT.Domain.Common.Models;

namespace KT.Domain.LibraryAggregate.Entities;

public class SessionPlanTemplate : Entity
{
    // parent id
    public Guid CourseTemplateId { get; private set; }


    // entities
    private readonly List<SessionTemplate> _sessionTemplates = [];
    public IReadOnlyCollection<SessionTemplate> SessionTemplates => _sessionTemplates.AsReadOnly();


    // value objects


    private SessionPlanTemplate(Guid id, Guid courseTemplateId) : base(id)
    {
        CourseTemplateId = courseTemplateId;
    }


    public static SessionPlanTemplate Create(Guid courseTemplateId)
    {
        var sessionPlanTemplate = new SessionPlanTemplate(Guid.NewGuid(), courseTemplateId);
        
        return sessionPlanTemplate;
    }

    public void AddSessionTemplate(SessionTemplate sessionTemplate)
    {
        _sessionTemplates.Add(sessionTemplate);
    }

    public void RemoveSessionTemplate(SessionTemplate sessionTemplate)
    {
        _sessionTemplates.Remove(sessionTemplate);
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private SessionPlanTemplate(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
