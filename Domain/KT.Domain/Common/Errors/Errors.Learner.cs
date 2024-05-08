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

    public static class LearningPlan
    {
        public static Error NotFound => Error.NotFound(
            code: "LearningPlan.NotFound",
            description: "A Learning Plan with this id does not exist.");
    }
}