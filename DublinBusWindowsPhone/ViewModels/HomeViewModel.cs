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
using Microsoft.Phone.Reactive;
using System.Linq;
using System.Collections.Generic;

namespace DublinBusWindowsPhone.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(Repository repo)
        {
            this.BusStops = new ObservableCollection<BusStopViewModel>();

            var repo = new Repository();
            this.BusStops = new ObservableCollection<BusStopViewModel>(repo.GetAllKnownBusStops());
        }

        private string busStopnumber;

        public string BusStopNumber
        {
            get
            {
                return this.busStopnumber;
            }

            set
            {
                this.busStopnumber = value;
                this.RaisePropertyChanged(() => this.BusStopNumber);
            }
        }

        private IEnumerable<BusStopViewModel> busStops;

        public IEnumerable<BusStopViewModel> BusStops
        {
            get
            {
                return this.busStops;
            }

            set
            {
                this.busStops = value;
                this.RaisePropertyChanged(() => this.BusStops);
            }
        }
    }
}
