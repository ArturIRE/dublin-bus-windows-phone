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
using DublinBusWindowsPhone.Helpers;
using System.IO.IsolatedStorage;
using System.Collections.ObjectModel;

namespace DublinBusWindowsPhone.ViewModels
{
    public class FavouriteStopsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<int> favouriteStops;

        public FavouriteStopsViewModel()
        {
            this.favouriteStops = new ObservableCollection<int>();
        }

        private void LoadFavourites()
        {
            var storage = IsolatedStorageSettings.ApplicationSettings;

            var stops = storage.Contains("FavouriteStops")
                ? (int[])storage["FavouriteStops"] 
                : new int[] { };

            foreach (var stop in stops)
            {
                this.FavouriteStops.Add(stop);
            }
        }

        public ObservableCollection<int> FavouriteStops 
        {
            get
            {
                return this.favouriteStops;
            }
        }
    }
}
