using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class CourseTemplate
    {
        public static Error NotFound => Error.NotFound(
            code: "CourseTemplate.NotFound",
            description: "A CourseTemplate with this id does not exist.");
    }

}
