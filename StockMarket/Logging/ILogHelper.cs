// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogHelper.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the ConsoleLogHelper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.Logging
{
    using System;

    /// <summary>
    /// The LogHelper interface.
    /// </summary>
    public interface ILogHelper
    {
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogMessage(string message);

        /// <summary>
        /// Logs details about the exception that has occurred.
        /// </summary>
        /// <param name="ex">The exception to be logged.</param>
        void LogException(Exception ex);

        /// <summary>
        /// Logs details about the exception that has occurred.
        /// </summary>
        /// <param name="message">The exception message to be logged.</param>
        void LogException(string message);
    }
}
