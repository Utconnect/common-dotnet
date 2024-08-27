using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Utconnect.Common.Models.Errors;

namespace Utconnect.Common.Models
{
    /// <summary>
    /// Represents the result of an operation with a data payload and error information.
    /// </summary>
    /// <typeparam name="T">The type of the data payload.</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Gets or sets the data payload of the result.
        /// </summary>
        public T Data { get; set; } = default!;

        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the collection of errors associated with the result.
        /// </summary>
        public IEnumerable<Error>? Errors { get; set; }

        /// <summary>
        /// Creates a successful result with the specified data.
        /// </summary>
        /// <param name="data">The data payload.</param>
        /// <returns>A <see cref="Result{T}"/> indicating success with the provided data.</returns>
        public static Result<T> Succeed(T data)
        {
            return new Result<T>
            {
                Success = true,
                Data = data
            };
        }

        /// <summary>
        /// Creates a failed result with the specified error.
        /// </summary>
        /// <param name="error">The error associated with the failure.</param>
        /// <returns>A <see cref="Result{T}"/> indicating failure with the provided error.</returns>
        public static Result<T> Failure(Error error)
        {
            return new Result<T>
            {
                Data = default!,
                Success = false,
                Errors = new List<Error> { error }
            };
        }

        /// <summary>
        /// Creates a failed result with a collection of errors.
        /// </summary>
        /// <param name="errors">The collection of errors associated with the failure.</param>
        /// <returns>A <see cref="Result{T}"/> indicating failure with the provided errors.</returns>
        public static Result<T> Failure(IEnumerable<Error> errors)
        {
            return new Result<T>
            {
                Data = default!,
                Success = false,
                Errors = errors
            };
        }

        /// <summary>
        /// Creates a failed result from a collection of <see cref="IdentityError"/> objects.
        /// </summary>
        /// <param name="errors">The collection of identity errors.</param>
        /// <returns>A <see cref="Result{T}"/> indicating failure with errors converted from <see cref="IdentityError"/> objects.</returns>
        public static Result<T> FromIdentityErrors(IEnumerable<IdentityError> errors)
        {
            return new Result<T>
            {
                Data = default!,
                Success = false,
                Errors = errors.Select(e => new MessageError(e.Description))
            };
        }
    }

    /// <summary>
    /// Represents the result of an operation with a boolean data payload and error information.
    /// </summary>
    public class Result : Result<bool>
    {
        /// <summary>
        /// Creates a successful result without a specific data payload.
        /// </summary>
        /// <returns>A <see cref="Result"/> indicating success.</returns>
        public static Result Succeed()
        {
            return new Result
            {
                Success = true,
                Data = true
            };
        }

        /// <summary>
        /// Creates a failed result with the specified error.
        /// </summary>
        /// <param name="error">The error associated with the failure.</param>
        /// <returns>A <see cref="Result"/> indicating failure with the provided error.</returns>
        public new static Result Failure(Error error)
        {
            return new Result
            {
                Data = false,
                Success = false,
                Errors = new List<Error> { error }
            };
        }

        /// <summary>
        /// Creates a failed result from a collection of FluentValidation failures.
        /// </summary>
        /// <param name="failures">The collection of FluentValidation failures.</param>
        /// <returns>A <see cref="Result"/> indicating failure with errors converted from FluentValidation failures.</returns>
        public static Result FromFluentValidationFailures(List<ValidationFailure> failures)
        {
            return new Result
            {
                Data = false,
                Success = false,
                Errors = failures.Select(f => new ValidationError(f.PropertyName, f.ErrorMessage))
            };
        }

        /// <summary>
        /// Creates a failed result from a collection of <see cref="IdentityError"/> objects.
        /// </summary>
        /// <param name="errors">The collection of identity errors.</param>
        /// <returns>A <see cref="Result"/> indicating failure with errors converted from <see cref="IdentityError"/> objects.</returns>
        public new static Result FromIdentityErrors(IEnumerable<IdentityError> errors)
        {
            return new Result
            {
                Data = false,
                Success = false,
                Errors = errors.Select(e => new MessageError(e.Description))
            };
        }
    }
}