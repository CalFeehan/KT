using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Learner
    {
        public static Error NotFound => Error.NotFound(
            code: "Learner.NotFound",
            description: "A Learner with this id does not exist.");
    }
}