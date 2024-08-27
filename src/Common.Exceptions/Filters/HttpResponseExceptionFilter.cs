using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Utconnect.Common.Exceptions.Core;
using Utconnect.Common.Models;
using Utconnect.Common.Models.Errors;

namespace Utconnect.Common.Exceptions.Filters
{
    /// <summary>
    /// A filter that handles exceptions thrown during the execution of an HTTP request and converts them into an appropriate HTTP response.
    /// </summary>
    /// <remarks>
    /// This filter converts various exceptions into an <see cref="HttpException"/> and formats the response accordingly.
    /// </remarks>
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseExceptionFilter"/> class.
        /// </summary>
        /// <param name="hostEnvironment">The current hosting environment. Used to determine if detailed error messages should be shown.</param>
        public HttpResponseExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// Called when an exception occurs during the execution of an action.
        /// </summary>
        /// <param name="context">The <see cref="ExceptionContext"/> that contains information about the exception and the context in which it occurred.</param>
        public void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;
            HttpException exceptionToHandle;

            switch (exception)
            {
                case HttpException httpException:
                    exceptionToHandle = httpException;
                    break;
                case InnerException innerException:
                    exceptionToHandle = innerException.WrapException();
                    break;
                default:
                {
                    List<Error> errorResponse = new List<Error> { new InternalServerError(exception.Message) };
                    string message = _hostEnvironment.IsEnvironment(Environments.Development)
                        ? exception.Message
                        : "Server error";
                    exceptionToHandle =
                        new HttpException(HttpStatusCode.InternalServerError, errorResponse, message, exception);
                    break;
                }
            }

            Result<bool> response = new Result<bool>
            {
                Success = false,
                Errors = exceptionToHandle.Errors
            };

            context.Result = new JsonResult(response)
            {
                StatusCode = (int?)exceptionToHandle.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}