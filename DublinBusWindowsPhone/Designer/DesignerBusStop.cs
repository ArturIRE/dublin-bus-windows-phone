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

namespace DublinBusWindowsPhone.Designer
{
    public class DesignerBusStop : ViewModelBase
    {
        public DesignerBusStop()
        {
            this.BusStopNumber = "1377";
            this.BusStopName = "South Circular Road, The Paddocks";
        }

        public string BusStopNumber { get; private set; }

        public string BusStopName { get; private set; }
    }
}
