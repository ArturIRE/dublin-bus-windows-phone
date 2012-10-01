//-------------------------------------------------------------------------
// <copyright file="CodeContractsHelpers.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Helpers
{
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Static class which provides helper methods relating to the .NET
    /// frameworks code contracts
    /// </summary>
    public static class CodeContractsHelpers
    {
        /// <summary>
        /// Workaround for the lack of Pure attribute on the Regex.IsMatch
        /// method. Simply proxies the Regex.IsMatch method
        /// </summary>
        /// <param name="value">The string to match</param>
        /// <param name="pattern">The regular expressions to match</param>
        /// <returns>True if the string matches the pattern</returns>
        [Pure]
        public static bool IsMatch(this string value, string pattern)
        {
            Contract.Requires(value != null);
            Contract.Requires(pattern != null);

// ReSharper disable AssignNullToNotNullAttribute
            return Regex.IsMatch(value, pattern);
// ReSharper restore AssignNullToNotNullAttribute
        }
    }
}
