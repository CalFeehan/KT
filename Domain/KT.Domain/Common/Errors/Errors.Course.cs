using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Course
    {
        public static Error NotFound => Error.NotFound(
            "Course.NotFound",
            "A Course with this id does not exist.");
    }
}