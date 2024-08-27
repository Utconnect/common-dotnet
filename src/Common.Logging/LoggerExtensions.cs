using System;
using Microsoft.Extensions.Logging;

namespace Utconnect.Common.Logging
{
    /// <summary>
    /// Provides extension methods for logging errors using an <see cref="ILogger"/>.
    /// </summary>
    public static class LoggerExtensions
    {
        private static readonly Action<ILogger, string, Exception?> LoggerError =
            LoggerMessage.Define<string>(LogLevel.Error, new EventId(5), "Error : {Message}");

        /// <summary>
        /// Logs an error message with <see cref="LogLevel.Error"/> level.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> instance used to log the message.</param>
        /// <param name="message">The error message to log.</param>
        public static void Error(this ILogger logger, string message) => LoggerError(logger, message, null);
    }
}