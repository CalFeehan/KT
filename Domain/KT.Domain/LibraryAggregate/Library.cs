using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.LibraryAggregate.Entities;

namespace KT.Domain.LibraryAggregate;

public class Library : AggregateRoot
{
    // entities
    private readonly List<CourseTemplate> _courseTemplates = [];
    public IReadOnlyCollection<CourseTemplate> CourseTemplates => _courseTemplates.AsReadOnly();

    // value objects
    public LibraryType LibraryType { get; private set; }

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
