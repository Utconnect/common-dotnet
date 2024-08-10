using System.Net;

namespace Utconnect.Common.Models.Errors;

public class InternalServerError(string message = "Server error")
    : Error(HttpStatusCode.InternalServerError, message);