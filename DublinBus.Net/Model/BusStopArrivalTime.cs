//-------------------------------------------------------------------------
// <copyright file="GlobalSupressions.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBus.Net.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BusStopArrivalTime
    {
        private readonly string routeNumber;

        private readonly string finalStopName;

        public readonly int minutesUntilArrival;

        public BusStopArrivalTime(string routeNumber, string finalStopName, int minutesUntilArrival)
        {
            Contract.Requires(Regex.IsMatch(routeNumber, "[0-9]+[abcdx]?"));
            Contract.Requires(!string.IsNullOrEmpty(finalStopName));
            Contract.Requires(minutesUntilArrival > 0);

            this.routeNumber = routeNumber;
            this.finalStopName = finalStopName;
            this.minutesUntilArrival = minutesUntilArrival;
        }

        public string RouteNumber
        {
            get
            {
                return this.routeNumber;
            }
        }

        public string FinalStopName
        {
            get
            {
                return this.finalStopName;
            }
        }

        public int MinutesUntilArrival
        {
            get
            {
                return this.minutesUntilArrival;
            }
        }
    }
}
