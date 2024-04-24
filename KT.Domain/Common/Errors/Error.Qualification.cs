using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Domain.Common.Errors;

public static partial class Errors
{
    public static class Qualification
    {
        public static Error NotFound => Error.NotFound(
            code: "Qualification.NotFound",
            description: "A qualification with this id does not exist.");
    }
}