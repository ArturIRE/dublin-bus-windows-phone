//-------------------------------------------------------------------------
// <copyright file="BusStopArrivalTime.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBus.Net.Model
{
    using System.Text.RegularExpressions;
    using C = System.Diagnostics.Contracts.Contract;

    public class BusStopArrivalTime
    {
        private readonly string routeNumber;

        private readonly string finalStopName;

        private readonly int minutesUntilArrival;

        public BusStopArrivalTime(string routeNumber, string finalStopName, int minutesUntilArrival)
        {
            C.Requires(Regex.IsMatch(routeNumber, "[0-9]+[abcdx]?"));
            C.Requires(!string.IsNullOrEmpty(finalStopName));
            C.Requires(minutesUntilArrival > 0);

            this.routeNumber = routeNumber;
            this.finalStopName = finalStopName;
            this.minutesUntilArrival = minutesUntilArrival;
        }

        public string RouteNumber
        {
            get
            {
                C.Ensures(Regex.IsMatch(C.Result<string>(), "[0-9]+[abcdx]?"));
                return this.routeNumber;
            }
        }

        public string FinalStopName
        {
            get
            {
                C.Ensures(!string.IsNullOrEmpty(C.Result<string>())); 
                return this.finalStopName;
            }
        }

        public int MinutesUntilArrival
        {
            get
            {
                C.Ensures(C.Result<int>() > 0);
                return this.minutesUntilArrival;
            }
        }
    }
}
