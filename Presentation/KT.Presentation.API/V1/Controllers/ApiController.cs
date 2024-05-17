using ErrorOr;
using KT.Presentation.API.Common.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KT.Presentation.API.V1.Controllers;

/// <summary>
///     Base class for API controllers.
/// </summary>
[ApiController]
public abstract class ApiController : ControllerBase
{
    /// <summary>
    ///     Create a ProblemDetails object.
    /// </summary>
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0) return Problem();

        // if all errors are validation errors, return a validation problem
        if (errors.All(e => e.Type == ErrorType.Validation)) return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors[0]);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelState = new ModelStateDictionary();
        foreach (var error in errors) modelState.AddModelError(error.Code, error.Description);
        return ValidationProblem(modelState);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }
}