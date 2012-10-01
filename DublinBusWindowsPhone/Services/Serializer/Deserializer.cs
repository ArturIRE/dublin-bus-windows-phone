//-------------------------------------------------------------------------
// <copyright file="Deserializer.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Services.Serializer
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Xml.Linq;
    using DublinBusWindowsPhone.Model;

    /// <summary>
    /// This class converts/deserializes DublinBus web-service xml response
    /// data into domain objects
    /// </summary>
    public class Deserializer
    {
        /// <summary>
        /// Converts a <see cref="XContainer"/> DublinBus web-service response
        /// to a set of <see cref="BusStopArrivalTime"/>s.
        /// </summary>
        /// <param name="document">
        /// The XML document response from DublinBus web service call to get
        /// real time bus stop information
        /// </param>
        /// <returns>
        /// A list of <see cref="BusStopArrivalTime"/> domain objects parsed
        /// from the supplied XML
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "by design")]
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "by design")]
        public ReadOnlyCollection<BusStopArrivalTime> DeserializeBusStopArrivalTimes(XContainer document)
        {
            Contract.Requires(document != null);
            Contract.Ensures(
                Contract.Result<ReadOnlyCollection<BusStopArrivalTime>>() != null);

            var list = new List<BusStopArrivalTime>();

// ReSharper disable PossibleNullReferenceException
// ReSharper disable LoopCanBeConvertedToQuery
            foreach (var xmlBusStopArrivaltime in document.Descendants("StopData"))
// ReSharper restore LoopCanBeConvertedToQuery
// ReSharper restore PossibleNullReferenceException
            {
                var routeNumber = GetValue(
                    xmlBusStopArrivaltime,
                    "MonitoredVehicleJourney_PublishedLineName");

                var finalDestination = GetValue(
                    xmlBusStopArrivaltime,
                    "MonitoredVehicleJourney_DestinationName");

                var expectedArrivalTime = GetDateValue(
                    xmlBusStopArrivaltime,
                    "MonitoredCall_ExpectedArrivalTime");
                
                var currentServerTime = GetDateValue(
                    xmlBusStopArrivaltime,
                    "StopMonitoringDelivery_ResponseTimestamp");

                var minutesUntilArrival = Convert.ToInt32(
                    expectedArrivalTime
                        .Subtract(currentServerTime)
                        .TotalMinutes);

                list.Add(new BusStopArrivalTime(
                    routeNumber,
                    finalDestination,
                    minutesUntilArrival));
            }

            return new ReadOnlyCollection<BusStopArrivalTime>(list);
        }

        /// <summary>
        /// Gets a child-element value for the supplied element, throwing
        /// <see cref="DeserializationException"/> if the data is missing
        /// </summary>
        /// <param name="xmlBusStopArrivaltime">
        /// An <see cref="XElement"/> object containing a bus stop arrival time
        /// </param>
        /// <param name="name">The name of the child-element</param>
        /// <returns>The string value of the child-element</returns>
        private static string GetValue(XContainer xmlBusStopArrivaltime, string name)
        {
            Contract.Requires(xmlBusStopArrivaltime != null);
            Contract.Requires(!string.IsNullOrEmpty(name));

// ReSharper disable PossibleNullReferenceException
            var element = xmlBusStopArrivaltime.Element(name);
// ReSharper restore PossibleNullReferenceException
            if (element == null)
            {
                throw new DeserializationException(string.Format(
                    CultureInfo.InvariantCulture, 
                    "Missing element for {0}", 
                    name));
            }

            if (string.IsNullOrEmpty(element.Value))
            {
                throw new DeserializationException(string.Format(
                    CultureInfo.InvariantCulture,
                    "Missing value for {0} in {1}",
                    name,
                    element));
            }

            return element.Value;
        }

        /// <summary>
        /// Gets the value of a child element and converts it to a 
        /// <see cref="DateTime"/>, throwing
        /// <see cref="DeserializationException"/>s if the data is missing or
        /// cannot be converted to a <see cref="DateTime"/>
        /// </summary>
        /// <param name="xmlBusStopArrivaltime">
        /// An <see cref="XElement"/> object containing a bus stop arrival time
        /// </param>
        /// <param name="name">The name of the child-element</param>
        /// <returns>The string value of the child-element</returns>
        private static DateTime GetDateValue(XContainer xmlBusStopArrivaltime, string name)
        {
            Contract.Requires(xmlBusStopArrivaltime != null);
            Contract.Requires(!string.IsNullOrEmpty(name));

            var value = GetValue(xmlBusStopArrivaltime, name);

            try
            {
                return DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                throw new DeserializationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Value doesn't look like a date {0} in {1}",
                        value,
                        xmlBusStopArrivaltime),
                    e);
            }
        }
    }
}
