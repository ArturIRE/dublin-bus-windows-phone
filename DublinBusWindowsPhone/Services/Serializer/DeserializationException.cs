//-------------------------------------------------------------------------
// <copyright file="DeserializationException.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Services.Serializer
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Deserialization exceptions are thrown when an attempt to convert
    /// some of the DublinBus web-service xml response data into domain objects
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "by design")]
    public class DeserializationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="DeserializationException"/> class
        /// </summary>
        /// <param name="message">
        /// A message indicating the cause of the exception
        /// </param>
        public DeserializationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DeserializationException"/> class
        /// </summary>
        /// <param name="message">
        /// A message indicating the cause of the exception
        /// </param>
        /// <param name="innerException">
        /// A caught exception that led to this exception
        /// </param>
        public DeserializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
