using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.LibraryAggregate.Entities;

namespace KT.Domain.LibraryAggregate;

/// <summary>
/// A library is used to store a collection of course templates.
/// </summary>
public class Library : AggregateRoot
{
    /// <summary>
    /// The inner collection of course templates.
    /// Note: This is a private collection, so it can only be modified by the Library itself.
    /// </summary>
    private readonly List<CourseTemplate> _courseTemplates = [];

    /// <summary>
    /// The public accessor for the course templates.
    /// This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyCollection<CourseTemplate> CourseTemplates => _courseTemplates.AsReadOnly();


    /// <summary>
    /// The type of library.
    /// </summary>
    public LibraryType LibraryType { get; private set; }

    /// <summary>
    /// Creates a new library.
    /// This should only be used once to create the System library, and then once per Tenant.
    /// </summary>
    public static Library Create()
    {
        var library = new Library(Guid.NewGuid());

        return library;
    }


    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Library(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}
