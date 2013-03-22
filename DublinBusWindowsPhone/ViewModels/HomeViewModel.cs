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
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using DublinBusWindowsPhone.Services;

namespace DublinBusWindowsPhone.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            //var repo = new Repository();
            //this.BusStops = new ObservableCollection<BusStopViewModel>(repo.GetAllKnownBusStops());
        }

        public ObservableCollection<BusStopViewModel> BusStops
        { get; set; }
    }
}
