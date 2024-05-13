using ErrorOr;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class ModuleTemplate
    {
        public static Error NotFound => Error.NotFound(
            code: "ModuleTemplate.NotFound",
            description: "A Module with this id does not exist.");
    }
}
