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
using DublinBusWindowsPhone.ViewModels;
using System.Collections.ObjectModel;

namespace DublinBusWindowsPhone.Designer
{
    public class HomeDesigner
    {
        public HomeDesigner()
        {
            this.BusStops = new ObservableCollection<BusStopViewModel>();
            this.BusStops.Add(new BusStopViewModel { BusStopName = "South Circular Road, The Paddocks", BusStopNumber = "1377" });
            this.BusStops.Add(new BusStopViewModel { BusStopName = "Leixlip Louisa Bridge", BusStopNumber = "3751" });
            this.BusStops.Add(new BusStopViewModel { BusStopName = "Dame St, Central Bank", BusStopNumber = "282" });
            this.BusStops.Add(new BusStopViewModel { BusStopName = "Liffey Valley, M50", BusStopNumber = "2099" });
            this.BusStops.Add(new BusStopViewModel { BusStopName = "Thomas St, Guiness Store House", BusStopNumber = "1548" });
        }

        public ObservableCollection<BusStopViewModel> BusStops { get; private set; }
    }
}
