using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Session
    {
        public static Error NotFound => Error.NotFound(
            code: "Session.NotFound",
            description: "A Session with this id does not exist.");
    }

}
