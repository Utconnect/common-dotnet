using System.Net;
using Common.Exceptions.Core;
using Common.Models;
using Common.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace Common.Exceptions.Filters;

public class HttpResponseExceptionFilter(IHostEnvironment hostEnvironment) : IExceptionFilter
{
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
                List<Error> errorResponse = [new InternalServerError(exception.Message)];
                string message = hostEnvironment.IsEnvironment(Environments.Development)
                    ? exception.Message
                    : "Server error";
                exceptionToHandle =
                    new HttpException(HttpStatusCode.InternalServerError, errorResponse, message, exception);
                break;
            }
        }

        Result<bool> response = new()
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