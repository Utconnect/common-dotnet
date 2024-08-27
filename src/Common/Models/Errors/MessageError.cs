namespace Utconnect.Common.Models.Errors
{
    /// <summary>
    /// Represents a general error with a message but without an associated HTTP status code or property information.
    /// </summary>
    public class MessageError : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageError"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public MessageError(string message) : base(message)
        {
        }
    }
}