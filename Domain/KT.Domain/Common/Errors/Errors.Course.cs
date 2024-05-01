using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Course
    {
        public static Error NotFound => Error.NotFound(
            code: "Course.NotFound",
            description: "A Course with this id does not exist.");
    }
}
