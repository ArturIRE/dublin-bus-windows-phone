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
using System.Collections.ObjectModel;
using DublinBusWindowsPhone.Model;

namespace DublinBusWindowsPhone.Designer
{
    public class BusStopTimesDesigner
    {
        public BusStopTimesDesigner()
        {
            this.ArrivalTimes = new ObservableCollection<BusStopArrivalTime>
            {
                new BusStopArrivalTime("68a", "Dolphins Barn", 14),
                new BusStopArrivalTime("40", "Liffey Valley", 34),
                new BusStopArrivalTime("747", "Dublin Airport via something something", 58),
            };
        }

        public ObservableCollection<BusStopArrivalTime> ArrivalTimes { get; set; }
    }
}
