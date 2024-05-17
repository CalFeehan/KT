using KT.Domain.Common.Models;

namespace KT.Domain.CourseTemplateAggregate.Entities;

/// <summary>
///     A session plan template holds all of the details needed to create a series of sessions,
///     including all details of those sessions.
/// </summary>
public class SessionPlanTemplate : Entity
{
    /// <summary>
    ///     The inner collection of session templates.
    ///     Note: This is a private collection, so it can only be modified by the SessionPlanTemplate itself.
    /// </summary>
    private readonly List<SessionTemplate> _sessionTemplates = [];

    /// <summary>
    ///     Creates a new session plan template.
    ///     Private constructor to ensure that the only way to create a session plan template is through the Create method.
    /// </summary>
    private SessionPlanTemplate(Guid id, Guid courseTemplateId) : base(id)
    {
        CourseTemplateId = courseTemplateId;
    }


    #region EF Core Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private SessionPlanTemplate(Guid id) : base(id)
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    #endregion

    /// <summary>
    ///     The course template that this session plan template belongs to.
    /// </summary>
    public Guid CourseTemplateId { get; private set; }

    /// <summary>
    ///     The public accessor for the session templates.
    ///     This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyCollection<SessionTemplate> SessionTemplates => _sessionTemplates.AsReadOnly();

    /// <summary>
    ///     Creates a new session plan template.
    ///     This should only be used once per course template.
    /// </summary>
    public static SessionPlanTemplate Create(Guid courseTemplateId)
    {
        var sessionPlanTemplate = new SessionPlanTemplate(Guid.NewGuid(), courseTemplateId);

        return sessionPlanTemplate;
    }

    /// <summary>
    ///     Adds a session template to the session plan template.
    /// </summary>
    public void AddSessionTemplate(SessionTemplate sessionTemplate)
    {
        _sessionTemplates.Add(sessionTemplate);
    }

    /// <summary>
    ///     Removes a session template from the session plan template.
    /// </summary>
    public void RemoveSessionTemplate(SessionTemplate sessionTemplate)
    {
        _sessionTemplates.Remove(sessionTemplate);
    }
}