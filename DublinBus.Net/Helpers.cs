//-------------------------------------------------------------------------
// <copyright file="Helpers.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBus.Net
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Set of static and extension helper functions
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlSwampedTimes"></param>
        /// <returns></returns>
        public static IEnumerable<string> ExtractBusTimesFromHtml(string htmlSwampedTimes)
        {
            var stripped = htmlSwampedTimes.Replace("<html><head><title>api</title></head><body>", string.Empty);
            stripped = stripped.Replace("</body></html>", string.Empty);

            foreach (var waitTime in stripped.Split(new[] { "<br/>" }, StringSplitOptions.None))
            {
                yield return waitTime;
            }
        }
    }
}
