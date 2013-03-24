using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Linq;
using DublinBusWindowsPhone.ViewModels;
using Microsoft.Phone.Reactive;
using DublinBusWindowsPhone.Model;
using Generated;

namespace DublinBusWindowsPhone.Services
{
    public class Repository : IRepository
    {
        private const string BusStopsTable = "BusStops";

        private IDictionary<string, object> objectStore;
        private Generated.DublinBusRTPIServiceSoap webService;

        public Repository(IDictionary<string, object> persistentStorage, Generated.DublinBusRTPIServiceSoap webService)
        {
            this.webService = webService;
            this.objectStore = IsolatedStorageSettings.ApplicationSettings;
        }

        public List<BusStopViewModel> GetAllKnownBusStops()
        {
            if (!this.objectStore.ContainsKey(BusStopsTable))
            {
                this.objectStore.Add(BusStopsTable, new List<BusStopViewModel>());
            }

            return (List<BusStopViewModel>)this.objectStore[BusStopsTable];
        }

        public void Save(BusStopViewModel busStop)
        {
            var allStops = this.GetAllKnownBusStops();
            allStops.Add(busStop);
            this.objectStore[BusStopsTable] = allStops;
        }

        private IEnumerable<BusStop> CachedBusStops
        {
            get
            {
                if (this.objectStore.ContainsKey(BusStopsTable))
                {
                    var cachedStops = (CacheEntry<IEnumerable<BusStop>>)this.objectStore[BusStopsTable];

                    // if cache is still fresh
                    if (cachedStops.Created.AddDays(7) < DateTime.UtcNow)
                    {
                        return cachedStops.Data;
                    }
                }

                return null;
            }

            set
            {
                if (value == null)
                {
                    this.objectStore.Remove(BusStopsTable);
                }
                else
                {
                    this.objectStore[BusStopsTable] = new CacheEntry<IEnumerable<BusStop>>
                    {
                        Created = DateTime.UtcNow,
                        Data = value
                    };
                }
            }
        }

        public IObservable<IEnumerable<BusStop>> RequestBusStops()
        {
            var cachedData = this.CachedBusStops;
            return cachedData == null
                    ? Observable.Return<IEnumerable<BusStop>>(cachedData)
                    : Observable.FromAsyncPattern<DestinationsResponse>(this.webService.BeginGetAllDestinations, this.webService.EndGetAllDestinations)()
                    .Select(resp => resp.Destinations.Select(dest => new BusStop {  }));

            
        }

        public IObservable<IEnumerable<Model.BusStop>> RequestBusStopsForRoute(string route)
        {
            throw new NotImplementedException();
        }

        public IObservable<IEnumerable<Model.BusStopArrivalTime>> RequestBusStopTimes(int busStopNumber)
        {
            throw new NotImplementedException();
        }

        public IObservable<IEnumerable<Model.BusRoute>> RequestBusRoutes()
        {
            throw new NotImplementedException();
        }
    }
}
