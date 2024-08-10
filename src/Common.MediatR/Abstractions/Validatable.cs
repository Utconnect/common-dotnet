using FluentValidation;
using FluentValidation.Results;
using Utconnect.Common.Models;

namespace Utconnect.Common.MediatR.Abstractions;

public abstract class Validatable
{
    protected static async Task<Result> ValidateAsync<T>(
        IValidator<T> validator,
        T request,
        CancellationToken cancellationToken)
    {
        ValidationResult? result = await validator.ValidateAsync(request, cancellationToken);
        return result.IsValid
            ? Result.Succeed()
            : Result.FromFluentValidationFailures(result.Errors);
    }
}