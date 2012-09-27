//-------------------------------------------------------------------------
// <copyright file="BusStopArrivalTime.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Model
{
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class that represents the a real-time bus stop entry.
    /// A simple POCO that contains a buses route number, final destination and
    /// the remaining minutes until the bus arrives at the stop.
    /// </summary>
    public class BusStopArrivalTime
    {
        /// <summary>The buses route number, e.g. 68a</summary>
        private readonly string routeNumber;

        /// <summary>The buses final destination</summary>
        private readonly string finalStopName;

        /// <summary>
        /// The estimated remaining minutes until the bus arrives
        /// </summary>
        private readonly int minutesUntilArrival;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusStopArrivalTime"/>
        /// class with supplied bus route number, final destination and
        /// estimated remaining minutes until the bus arrives.
        /// </summary>
        /// <param name="routeNumber">The buses route number, e.g. 68a</param>
        /// <param name="finalStopName">The buses final destination</param>
        /// <param name="minutesUntilArrival">
        /// The estimated remaining minutes until the bus arrives
        /// </param>
        public BusStopArrivalTime(
            string routeNumber, string finalStopName, int minutesUntilArrival)
        {
            Contract.Requires(Regex.IsMatch(routeNumber, "[0-9]+[abcdx]?"));
            Contract.Requires(!string.IsNullOrEmpty(finalStopName));
            Contract.Requires(minutesUntilArrival >= 0);

            this.routeNumber = routeNumber;
            this.finalStopName = finalStopName;
            this.minutesUntilArrival = minutesUntilArrival;
        }

        /// <summary>Gets the buses route number, e.g. 68a</summary>
        public string RouteNumber
        {
            get
            {
                Contract.Ensures(Regex.IsMatch(
                    Contract.Result<string>(), "[0-9]+[abcdx]?"));
                return this.routeNumber;
            }
        }

        /// <summary>Gets the buses final destination</summary>
        public string FinalStopName
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(
                    Contract.Result<string>())); 
                return this.finalStopName;
            }
        }

        /// <summary>
        /// Gets the estimated remaining minutes until the bus arrives
        /// </summary>
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
