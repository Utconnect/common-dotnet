using System.Net;

namespace Common.Models.Errors;

public class BadRequestError(string message = "This request cannot be handled")
    : Error(HttpStatusCode.BadRequest, message);