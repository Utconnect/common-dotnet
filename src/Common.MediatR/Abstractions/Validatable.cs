using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Utconnect.Common.Models;

namespace Utconnect.Common.MediatR.Abstractions
{
    /// <summary>
    /// Provides a base class for entities that require validation.
    /// </summary>
    public abstract class Validatable
    {
        /// <summary>
        /// Validates the specified request asynchronously using the provided validator.
        /// </summary>
        /// <typeparam name="T">The type of the request to validate.</typeparam>
        /// <param name="validator">The validator to use for validating the request.</param>
        /// <param name="request">The request to validate.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous validation result.</returns>
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
}