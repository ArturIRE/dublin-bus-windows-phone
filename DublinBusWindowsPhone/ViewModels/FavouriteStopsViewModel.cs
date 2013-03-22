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
using System.ComponentModel;

namespace DublinBusWindowsPhone.ViewModels
{
    public class FavouriteStopsViewModel : ViewModelBase
    {
        private ObservableCollection<string> favouriteStops;

        public FavouriteStopsViewModel()
        {
            this.favouriteStops = new ObservableCollection<string>();
            this.LoadFavourites();
        }

        private void LoadFavourites()
        {
            if (DesignerProperties.IsInDesignTool)
            {
                return;
            }

            var storage = IsolatedStorageSettings.ApplicationSettings;

            var stops = storage.Contains("FavouriteStops")
                ? (string[])storage["FavouriteStops"]
                : new string[] { };

            foreach (var stop in stops)
            {
                this.FavouriteStops.Add(stop);
            }
        }

        public ObservableCollection<string> FavouriteStops 
        {
            get
            {
                return this.favouriteStops;
            }

            protected set
            {
                this.favouriteStops = value;
                this.RaisePropertyChanged(() => this.FavouriteStops);
            }
        }
    }
}
