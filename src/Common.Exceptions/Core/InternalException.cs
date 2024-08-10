using System.Net;
using Utconnect.Common.Models.Errors;

namespace Utconnect.Common.Exceptions.Core;

public abstract class InternalServerErrorException(string? message, Exception? innerException = null)
    : InnerException(message, innerException)
{
    public override HttpException WrapException()
    {
        List<Error> errorResponse = [new InternalServerError(Message)];
        return new HttpException(HttpStatusCode.InternalServerError, errorResponse, Message, this);
    }
}