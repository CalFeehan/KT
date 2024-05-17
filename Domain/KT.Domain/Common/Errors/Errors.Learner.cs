using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Learner
    {
        public static Error NotFound => Error.NotFound(
            "Learner.NotFound",
            "A Learner with this id does not exist.");
    }
}