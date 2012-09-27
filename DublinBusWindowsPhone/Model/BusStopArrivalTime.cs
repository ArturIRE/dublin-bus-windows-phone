//-------------------------------------------------------------------------
// <copyright file="BusStopArrivalTime.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Model
{
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;

    public class BusStopArrivalTime
    {
        private readonly string routeNumber;

        private readonly string finalStopName;

        private readonly int minutesUntilArrival;

        public BusStopArrivalTime(string routeNumber, string finalStopName, int minutesUntilArrival)
        {
            Contract.Requires(Regex.IsMatch(routeNumber, "[0-9]+[abcdx]?"));
            Contract.Requires(!string.IsNullOrEmpty(finalStopName));
            Contract.Requires(minutesUntilArrival >= 0);

            this.routeNumber = routeNumber;
            this.finalStopName = finalStopName;
            this.minutesUntilArrival = minutesUntilArrival;
        }

        public string RouteNumber
        {
            get
            {
                Contract.Ensures(Regex.IsMatch(Contract.Result<string>(), "[0-9]+[abcdx]?"));
                return this.routeNumber;
            }
        }

        public string FinalStopName
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>())); 
                return this.finalStopName;
            }
        }

        public int MinutesUntilArrival
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return this.minutesUntilArrival;
            }
        }
    }
}
