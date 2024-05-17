using KT.Common.Enums;

namespace KT.Domain.CourseTemplateAggregate.Extensions;

/// <summary>
///     Extension methods for the CourseTemplate class.
/// </summary>
public static class CourseTemplateExtensions
{
    /// <summary>
    ///     Determines if the course template is editable.
    /// </summary>
    public static bool IsEditable(this CourseTemplate courseTemplate)
    {
        return courseTemplate.CourseTemplateStatus switch
        {
            CourseTemplateStatus.Draft => true,
            CourseTemplateStatus.Published => true,
            _ => false
        };
    }
}