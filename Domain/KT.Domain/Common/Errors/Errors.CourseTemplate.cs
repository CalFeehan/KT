using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class CourseTemplate
    {
        public static Error NotFound => Error.NotFound(
            "CourseTemplate.NotFound",
            "A CourseTemplate with this id does not exist.");
    }
}