// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogHelper.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the ConsoleLogHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.Logging
{
    using System;

    /// <summary>
    /// The console log helper.
    /// </summary>
    public class ConsoleLogHelper : ILogHelper
    {
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine($"{DateTime.UtcNow}   Information     {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Logs details about the exception that has occurred.
        /// </summary>
        /// <param name="ex">The exception to be logged.</param>
        public void LogException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Out.WriteLine($"{DateTime.UtcNow}   Exception     [{ex.GetType()}] {ex.Message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Logs details about the exception that has occurred.
        /// </summary>
        /// <param name="message">The exception message to be logged.</param>
        public void LogException(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Out.WriteLine($"{DateTime.UtcNow}   Exception     {message}");
            Console.ResetColor();
        }
    }
}
