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
using System.Windows.Navigation;

namespace DublinBusWindowsPhone.ViewModels
{
    public class BusStopViewModel : ViewModelBase
    {
        private string busStopNumber;
        private string busStopName;

        public BusStopViewModel()
        {
            this.busStopNumber = string.Empty;
            this.busStopName = string.Empty;
        }

        public string BusStopNumber
        {
            get
            {
                return this.busStopNumber;
            }
            set
            {
                this.busStopNumber = value;
                this.RaisePropertyChanged(() => BusStopNumber);
            }
        }

        public string BusStopName
        {
            get
            {
                return this.busStopName;
            }
            set
            {
                this.busStopName = value;
                this.RaisePropertyChanged(() => BusStopNumber);
            }
        }

        public Color Color
        {
            get
            {
                Random rnd = new Random();
                return Color.FromArgb((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255));
            }
        }
    }
}
