using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Student
    {
        public static Error NotFound => Error.NotFound(
            code: "Student.NotFound",
            description: "A student with this id does not exist.");
    }
}