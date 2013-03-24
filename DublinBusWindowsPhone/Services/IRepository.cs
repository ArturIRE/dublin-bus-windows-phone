// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DublinBusWindowsPhone.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DublinBusWindowsPhone.Model;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IRepository
    {
        IObservable<IEnumerable<BusStop>> RequestBusStops();

        IObservable<IEnumerable<BusStop>> RequestBusStopsForRoute(string route);

        IObservable<IEnumerable<BusStopArrivalTime>> RequestBusStopTimes(int busStopNumber);

        IObservable<IEnumerable<BusRoute>> RequestBusRoutes();
    }
}
