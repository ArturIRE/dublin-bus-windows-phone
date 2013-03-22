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
using DublinBusWindowsPhone.ViewModels;

namespace DublinBusWindowsPhone.Services
{
    public class Repository
    {
        private const string BusStopsTable = "BusStops";

        private IsolatedStorageSettings objectStore;

        public Repository()
        {
            this.objectStore = IsolatedStorageSettings.ApplicationSettings;
        }

        public List<BusStopViewModel> GetAllKnownBusStops()
        {
            if (!this.objectStore.Contains(BusStopsTable))
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
    }
}
