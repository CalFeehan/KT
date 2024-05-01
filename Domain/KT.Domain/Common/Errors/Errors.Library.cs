using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Library
    {
        public static Error NotFound => Error.NotFound(
            code: "Library.NotFound",
            description: "A Library with this id does not exist.");
    }

}
