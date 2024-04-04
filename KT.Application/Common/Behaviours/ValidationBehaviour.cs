using ErrorOr;
using FluentValidation;
using MediatR;

namespace KT.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IValidator<TRequest>? validator = null) 
    : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator = validator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // if no validator is provided, just continue
        if (_validator is null)
        {
            return await next();
        }

        // validate the request
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        // if the request is valid, continue
        if (validationResult.IsValid)
        {
            return await next();
        }

        // if the request is invalid, return the errors
        var errors = validationResult.Errors.
            ConvertAll(e => Error.Validation(
                e.PropertyName,
                e.ErrorMessage));

        return (dynamic)errors;
    }
}
