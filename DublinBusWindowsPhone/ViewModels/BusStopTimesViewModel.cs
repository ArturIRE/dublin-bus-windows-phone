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
using DublinBusWindowsPhone.Model;
using Microsoft.Phone.Reactive;

namespace DublinBusWindowsPhone.ViewModels
{
    public class BusStopTimesViewModel : ViewModelBase
    {
        private ObservableCollection<BusStopArrivalTime> arrivalTimes;

        public void LoadBusStopTimes(string busStopNumber)
        {
            var wc = new DublinBusWindowsPhone.Services.Web.DublinBusWebServiceClient();
            var obs = wc.GetBusStopArrivalTimes(int.Parse(busStopNumber));
            obs.Subscribe(times => this.ArrivalTimes = new ObservableCollection<BusStopArrivalTime>(times));
        }

        public ObservableCollection<BusStopArrivalTime> ArrivalTimes
        {
            get
            {
                return arrivalTimes;
            }

            set
            {
                arrivalTimes = value;
                this.RaisePropertyChanged(() => ArrivalTimes);
            }
        }
    }
}
