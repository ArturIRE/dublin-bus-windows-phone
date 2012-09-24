//-------------------------------------------------------------------------
// <copyright file="Helpers.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text.RegularExpressions;

    using DublinBusWindowsPhone.Model;
    using System.Globalization;

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
        public static IEnumerable<BusStopArrivalTime> ExtractBusTimesFromHtml(string htmlSwampedTimes)
        {
            var stripped = htmlSwampedTimes.Replace("<html><head><title>api</title></head><body>", string.Empty);
            stripped = stripped.Replace("</body></html>", string.Empty);

            foreach (var waitTime in stripped.Split(new[] { "<br/>" }, StringSplitOptions.None))
            {
                yield return ConvertToPoco(waitTime);
            }
        }

        private static BusStopArrivalTime ConvertToPoco(string dashSeperatedValues)
        {
            Contract.Ensures(Contract.Result<BusStopArrivalTime>() != null);

            var values = dashSeperatedValues.Split('-').Select(s => s.Trim()).ToList();

            if (values.Count != 3 || !ReturnedBusStopArrivalTimeAreValid(values[0], values[1], values[2]))
            {
                // Raise Invalid data error
                return new BusStopArrivalTime("999a", "No where", 60);
            }

            string routeNumber = values[0];
            string finalStopName = values[1];
            int minutesUntilArrival = int.Parse(values[2], CultureInfo.InvariantCulture);

            return new BusStopArrivalTime(routeNumber, finalStopName, minutesUntilArrival);
        }

        private static bool ReturnedBusStopArrivalTimeAreValid(string routeNumber, string finalStopName, string minutesUntilArrival)
        {
            if (!Regex.IsMatch(routeNumber, "[0-9]+[abcdx]?"))
            {
                return false;
            }

            if (string.IsNullOrEmpty(finalStopName))
            {
                return false;
            }

            if (!Regex.IsMatch(minutesUntilArrival, "[0-9]+"))
            {
                return false;
            }

            return true;
        }
    }
}
