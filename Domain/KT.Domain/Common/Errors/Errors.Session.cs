using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Session
    {
        public static Error NotFound => Error.NotFound(
            "Session.NotFound",
            "A Session with this id does not exist.");
    }
}