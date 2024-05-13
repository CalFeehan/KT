namespace KT.Common.Enums;

/// <summary>
/// The status of a course template.
/// </summary>
public static class CourseTemplateStatusExtensions
{
    /// <summary>
    /// Is valid transition.
    /// </summary>
    public static bool IsValidTransition(this CourseTemplateStatus currentStatus, CourseTemplateStatus newStatus)
    {
        return currentStatus switch
        {
            CourseTemplateStatus.Draft => newStatus is CourseTemplateStatus.Published,
            CourseTemplateStatus.Published => newStatus is CourseTemplateStatus.Active,
            _ => false
        };
    }
}
